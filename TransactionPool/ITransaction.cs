using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionPool
{
    public interface ITransaction
    {

        /*Song details to be entered in the Blockchain*/
        int SongNumber { get; set; }
        string SongName { get; set; }
        string AlbumName { get; set; }
        string ArtistOrBand { get; set; }
        string PublicationLabel { get; set; }
        int OwnershipPercentagePerBandMember { get; set; }
        string CalculateTransactionHash();

    }

}
