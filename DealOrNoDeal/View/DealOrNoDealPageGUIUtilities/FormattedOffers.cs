using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store.Preview.InstallControl;
using Windows.Security.Cryptography.Core;
using DealOrNoDeal.Model;

namespace DealOrNoDeal.View.DealOrNoDealPageGUIUtilities
{

    public class FormattedOffers
    {
        public string FormattedCurrentOffer { get; private set; }

        public string FormattedAverageOffer { get; private set; }

        public string FormattedMinimumOffer { get; private set; }

        public string FormattedMaximumOffer { get; private set; }

        private const string BankerOfferFormatOption = "C";

        public FormattedOffers()
        {

        }

        public void UpdateFormattedOffers(GameManager gameManager)
        {
            gameManager.GetOffer();
            this.FormattedCurrentOffer = gameManager.Banker.CurrentOffer.ToString(BankerOfferFormatOption);
            this.FormattedAverageOffer = gameManager.Banker.AverageOffer.ToString(BankerOfferFormatOption);
            this.FormattedMinimumOffer = gameManager.Banker.MinimumOffer.ToString(BankerOfferFormatOption);
            this.FormattedMaximumOffer = gameManager.Banker.MaximumOffer.ToString(BankerOfferFormatOption);
        }
    }
}
