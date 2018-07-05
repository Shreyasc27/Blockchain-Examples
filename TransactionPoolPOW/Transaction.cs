using BlockChain.SingleTransaction;
using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionPool
{
    public class Transaction : ITransaction
    {
        public int SongNumber { get; set; }
        public string SongName { get; set; }
        public string AlbumName { get; set; }
        public string ArtistOrBand { get; set; }
        public string PublicationLabel { get; set; }
        public int OwnershipPercentagePerBandMember { get; set; }

        public Transaction(int songNumber, string songName, string albumName,
            string artistOrBand, string publicationLabel, int ownershipPercentagePerBandMember)
        {

            SongNumber = songNumber;
            SongName = songName;
            AlbumName = albumName;
            ArtistOrBand = artistOrBand;
            PublicationLabel = publicationLabel;
            OwnershipPercentagePerBandMember = ownershipPercentagePerBandMember;

        }

        public string CalculateTransactionHash()
        {

            string songDetailString = null;

            songDetailString = SongNumber + SongName + AlbumName + ArtistOrBand + PublicationLabel + OwnershipPercentagePerBandMember;

            return Convert.ToBase64String(HashData.ComputeHashSha256(Encoding.UTF8.GetBytes(songDetailString)));

        }

    }

}
