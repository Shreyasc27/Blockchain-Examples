using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChain.SingleTransaction
{
    public class Block : IBlock
    {
        public int SongNumber { get; set; }
        public string SongName { get; set; }
        public string AlbumName { get; set; }
        public string ArtistOrBand { get; set; }
        public string PublicationLabel { get; set; }
        public int OwnershipPercentagePerBandMember { get; set; }
        public int BlockNumber { get; set; }
        public DateTime BlockCreationDate { get; set; }
        public string CurrentBlockHash { get; set; }
        public string PreviousBlockHash { get; set; }
        public IBlock NextBlock { get; set; }
        
        public Block(int blockNumber, int songNumber, string songName, string albumName, string artistOrBand,
            string publicationLabel, int ownershipPercentagePerBandMember, DateTime blockCreationDate, 
            IBlock previousBlock)
        {

            BlockNumber = blockNumber;
            SongNumber = songNumber;
            SongName = songName;
            AlbumName = albumName;
            ArtistOrBand = artistOrBand;
            PublicationLabel = publicationLabel;
            OwnershipPercentagePerBandMember = ownershipPercentagePerBandMember;
            BlockCreationDate = blockCreationDate;
            setblockHashOfBlock(previousBlock);

        }

        /*Calculate the hash of block which is combination of song details and block details.*/
        public string calculateBlockHash(string blockHashToCompute)
        {

            string songDetailString = null;
            string blockHashString = null;

            songDetailString = SongNumber + SongName + AlbumName + ArtistOrBand + PublicationLabel + OwnershipPercentagePerBandMember + BlockCreationDate;
            blockHashString = BlockNumber + BlockCreationDate.ToString() + blockHashToCompute;

            return Convert.ToBase64String(HashData.ComputeHashSha256(Encoding.UTF8.GetBytes(songDetailString + blockHashString)));

        }

        /*Validate if the chain is valid.*/
        public bool isValidChain(string parentBlockHash, bool verbose)
        {

            bool isValid = true;

            string newBlockHash = calculateBlockHash(parentBlockHash);

            if (newBlockHash != CurrentBlockHash)
            {

                isValid = false;

            }
            else
            {

                isValid = true;
                PreviousBlockHash = parentBlockHash;

            }

            displayBlockValidity(verbose, isValid);

            if (NextBlock != null)
            {

                return NextBlock.isValidChain(newBlockHash, verbose);

            }

            return isValid;

        }

        /*Use the hash of the previous block in the current block*/
        public void setblockHashOfBlock(IBlock previousBlock)
        {

            if (previousBlock != null)
            {

                PreviousBlockHash = previousBlock.CurrentBlockHash;
                previousBlock.NextBlock = this;

            }
            else
            {

                PreviousBlockHash = null;

            }

            CurrentBlockHash = calculateBlockHash(PreviousBlockHash);

        }

        /*Verify if the block is valid or not*/
        private void displayBlockValidity(bool verbose, bool isValid)
        {

            if (verbose)
            {

                if (isValid)
                {

                    Console.WriteLine("Block [" + BlockNumber + "] : Valid block on the chain!");

                }
                else
                {

                    Console.WriteLine("Block [" + BlockNumber + "] : Invalid block on the chain!");

                }

            }

        }

    }
}
