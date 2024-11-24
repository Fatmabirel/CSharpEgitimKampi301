using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        DbEgitimKampıEfTravelEntities db = new DbEgitimKampıEfTravelEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Locations.Count().ToString();

            lblSumCapacity.Text = db.Locations.Sum(x => x.Capacity).ToString();

            lblGuideCount.Text = db.Guides.Count().ToString();

            lblAvgCapacity.Text = db.Locations.Average(x => x.Capacity).ToString();

            lblAvgLocationPrice.Text = string.Format("{0:F2} ₺", db.Locations.Average(x => x.Price));

            int lastCountryId = db.Locations.Max(x => x.Id);
            lblLastCountryName.Text = db.Locations.Where(x => x.Id == lastCountryId).Select(y => y.Country).FirstOrDefault();

            lblCappadociaTourCapacity.Text = db.Locations.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();

            lblTurkiyeCapacityAvg.Text = db.Locations.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();

            var romeGuideId = db.Locations.Where(x => x.City == "Roma").Select(y => y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.Guides.Where(x => x.Id == romeGuideId).Select(y => y.Name + " " + y.Surname).FirstOrDefault().ToString();

            var maxCapacity = db.Locations.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text = db.Locations.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault().ToString();

            var maxPrice = db.Locations.Max(x => x.Price);
            lblMaxPriceLocation.Text = db.Locations.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();

            var guideIdByNameAysegulCinar = db.Guides.Where(x => x.Name == "Ayşegül" && x.Surname == "Çınar").Select(y => y.Id).FirstOrDefault();
            lblAysegülCinarLocationCount.Text = db.Locations.Where(x => x.GuideId == guideIdByNameAysegulCinar).Count().ToString();
        }
    }
}
