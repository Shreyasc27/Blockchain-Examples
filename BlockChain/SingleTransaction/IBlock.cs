using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChain.SingleTransaction
{
    public interface IBlock
    {

        /*Song details to be entered in the Blockchain*/
        int SongNumber { get; set; }
        string SongName { get; set; }
        string AlbumName { get; set; }
        string ArtistOrBand { get; set; }
        string PublicationLabel { get; set; }
        int OwnershipPercentagePerBandMember { get; set; }

        /*Block details*/
        int BlockNumber { get; set; }
        DateTime BlockCreationDate { get; set; }
        string CurrentBlockHash { get; set; }
        string PreviousBlockHash { get; set; }

        string calculateBlockHash(string blockHashToCompute);
        void setblockHashOfBlock(IBlock previousBlock);
        IBlock NextBlock { get; set; }
        bool isValidChain(string parentBlockHash, bool verbose);

    }
}
