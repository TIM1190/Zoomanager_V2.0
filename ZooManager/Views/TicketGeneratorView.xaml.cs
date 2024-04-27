using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZooManager.Services;
using ZooManager.Services.Imp;

namespace ZooManager.Views
{
    /// <summary>
    /// Interaction logic for TicketGeneratorView.xaml
    /// </summary>
    public partial class TicketGeneratorView : UserControl, INotifyPropertyChanged
    {
        private ITicketsRepository _ticketsRepository = new TicketsRepository();

        private bool _adultTicket = true;
        private bool _childTicket;
        private bool _discountTicket;
        private bool _excursion;
        private bool _fedingTheAnimals;
        private bool _photoshoot;
        private string _id;
        private string _ticketType;
        private double _price;
        private string _addServices;

        public string AddServices
        {
            get { return _addServices; }
            set
            {
                if (_addServices != value)
                {
                    _addServices = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string TicketType
        {
            get { return _ticketType; }
            set
            {
                if (_ticketType != value)
                {
                    _ticketType = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool AdultTicket
        {
            get { return _adultTicket; }
            set
            {
                if (_adultTicket != value)
                {
                    _adultTicket = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool ChildTicket
        {
            get { return _childTicket; }
            set
            {
                if (_childTicket != value)
                {
                    _childTicket = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool DiscountTicket
        {
            get { return _discountTicket; }
            set
            {
                if (_discountTicket != value)
                {
                    _discountTicket = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool Excursion
        {
            get { return _excursion; }
            set
            {
                if (_excursion != value)
                {
                    _excursion = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool FeedingTheAnimals
        {
            get { return _fedingTheAnimals; }
            set
            {
                if (_fedingTheAnimals != value)
                {
                    _fedingTheAnimals = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool Photoshoot
        {
            get { return _photoshoot; }
            set
            {
                if (_photoshoot != value)
                {
                    _photoshoot = value;
                    OnPropertyChanged();
                }
            }
        }

        public TicketGeneratorView()
        {
            InitializeComponent();
            DataContext = this;
            //GenerateTicket();
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        private void CreateTicket_Click(object sender, RoutedEventArgs e)
        {
            GenerateTicket();
        }

        private void GenerateTicket()
        {
            var addServices = new StringBuilder();
            addServices
                .Append(Excursion ? "Экскурсия;" : "")
                .Append(FeedingTheAnimals ? "Кормление животных;" : "")
                .Append(Photoshoot ? "Фотосессия;" : "");

            AddServices = addServices.ToString();

            var price = AdultTicket ? 2000 : ChildTicket ? 500 : 1700;

            if (Excursion)
                price += 100;
            if (FeedingTheAnimals)
                price += 300;
            if (Photoshoot)
                price += 500;

            Price = price;

            Id = Guid.NewGuid().ToString();
            TicketType = AdultTicket ? "Взрослый" : ChildTicket ? "Детский" : "Скидочный";

            var message = new StringBuilder();

            message
                .Append(Id)
                .Append(';')
                .Append(AdultTicket ? "A" : ChildTicket ? "B" : "C")
                .Append(';')
                .Append(Excursion ? "E;" : "")
                .Append(FeedingTheAnimals ? "F;" : "")
                .Append(Photoshoot ? "P;" : "")
                .Append(Price);

            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(
                message.ToString(), QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage = qrCode.GetGraphic(20, System.Drawing.Color.Black, System.Drawing.Color.LightGray, true);

            var memoryStream = new MemoryStream();
            qrCodeImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            memoryStream.Position = 0;
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = memoryStream;
            bi.EndInit();

            TicketImage.Source = bi;

            try
            {
                _ticketsRepository.Add(new Models.Ticket
                {
                    No = Id,
                    Excursion = this.Excursion,
                    FeedingTheAnimals = this.FeedingTheAnimals,
                    Photoshoot = this.Photoshoot,
                    Price = this.Price,
                    TicketType = this.TicketType
                });
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно добавить билет в БД.\nПовторите попытку позже.", "ZooManager",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
