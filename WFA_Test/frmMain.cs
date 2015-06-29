using ProjectTemplate.Core.Abstractions.Service;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Core.IoC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_Test
{
    public partial class frmMain : Form
    {

        private readonly IServiceActor _serviceActor;
        private readonly IServiceFilm _serviceFilm;
        private readonly IServiceDirector _serviceDirector;
        private readonly IServiceFilmType _serviceFilmType;
        private readonly IServiceProducer _serviceProducer;
        private readonly IServiceUser _serviceUser;
        private readonly IServiceWriter _serviceWriter;

        public frmMain(IServiceActor serviceActor, IServiceFilm serviceFilm, IServiceDirector serviceDirector, IServiceFilmType serviceFilmType, IServiceProducer serviceProducer, IServiceUser serviceUser, IServiceWriter serviceWriter)
        {
            _serviceActor = serviceActor;
            _serviceFilm = serviceFilm;
            _serviceDirector = serviceDirector;
            _serviceFilmType = serviceFilmType;
            _serviceProducer = serviceProducer;
            _serviceUser = serviceUser;
            _serviceWriter = serviceWriter;
            InitializeComponent();
        }

        public frmMain()
            : this(DependencyContainer.Current.Resolve<IServiceActor>(), DependencyContainer.Current.Resolve<IServiceFilm>(), DependencyContainer.Current.Resolve<IServiceDirector>(), DependencyContainer.Current.Resolve<IServiceFilmType>(), DependencyContainer.Current.Resolve<IServiceProducer>(), DependencyContainer.Current.Resolve<IServiceUser>(), DependencyContainer.Current.Resolve<IServiceWriter>())
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Random rd = new Random();
            string[] types = { "Korku", "Macera", "Gerilim", "Drama", "Polisiye", "Romantik", "Komedi" };

            List<Film> LSTFilm = new List<Film>();
            for (int i = 0; i < 10; i++)
            {
                Film Newfilm = new Film();
                Newfilm.Name = FakeData.NameData.GetCompanyName();
                Newfilm.PublishDate = FakeData.DateTimeData.GetDatetime();
                Newfilm.ImdbPoint = FakeData.NumberData.GetNumber(1, 9);
                Newfilm.PosterImgPath = "../../images/r" + FakeData.TextData.GetNumeric(1) + ".jpg";
                Newfilm.Website = FakeData.NetworkData.GetDomain();

                List<FilmType> LSTFlmtyp = new List<FilmType>();
                for (int k = 0; k < 6; k++)
                {
                    FilmType newflmtyp = new FilmType();
                    newflmtyp.TypeName = types[k];
                    newflmtyp.Movies = LSTFilm;

                    LSTFlmtyp.Add(newflmtyp);
                    _serviceFilmType.Insert(newflmtyp);
                }
                Newfilm.FilmTypes = LSTFlmtyp;

                List<Actor> LSTActr = new List<Actor>();
                for (int k = 0; k < 5; k++)
                {
                    Actor act = new Actor();
                    act.Name = FakeData.NameData.GetFirstName();
                    act.Surname = FakeData.NameData.GetSurname();
                    act.BirthDate = FakeData.DateTimeData.GetDatetime();
                    act.ImagePath = "../../images/gridallbum" + FakeData.TextData.GetNumeric(1) + ".jpg";
                    act.Movies = LSTFilm;

                    LSTActr.Add(act);
                    _serviceActor.Insert(act);
                }
                Newfilm.Actors = LSTActr;

                List<Director> LSTDrt = new List<Director>();
                for (int m = 0; m < 5; m++)
                {
                    Director drt = new Director();
                    drt.Name = FakeData.NameData.GetFirstName();
                    drt.Surname = FakeData.NameData.GetSurname();
                    drt.BirthDate = FakeData.DateTimeData.GetDatetime();
                    drt.ImagePath = "../../images/gridallbum" + FakeData.TextData.GetNumeric(1) + ".jpg";
                    drt.Movies = LSTFilm;

                    LSTDrt.Add(drt);
                    _serviceDirector.Insert(drt);
                }
                Newfilm.Directors = LSTDrt;

                List<Writer> LSTWrt = new List<Writer>();
                for (int m = 0; m < 5; m++)
                {
                    Writer wrt = new Writer();
                    wrt.Name = FakeData.NameData.GetFirstName();
                    wrt.Surname = FakeData.NameData.GetSurname();
                    wrt.BirthDate = FakeData.DateTimeData.GetDatetime();
                    wrt.ImagePath = "../../images/gridallbum" + FakeData.TextData.GetNumeric(1) + ".jpg";
                    wrt.Movies = LSTFilm;

                    LSTWrt.Add(wrt);
                    _serviceWriter.Insert(wrt);
                }
                Newfilm.Writers = LSTWrt;

                List<Producer> LSTPrd = new List<Producer>();
                for (int m = 0; m < 5; m++)
                {
                    Producer prd = new Producer();
                    prd.ChairManName = FakeData.NameData.GetFullName();
                    prd.CompanyName = FakeData.NameData.GetCompanyName();
                    prd.FormDate = FakeData.DateTimeData.GetDatetime();
                    prd.CompanyAddress = FakeData.PlaceData.GetAddress();
                    prd.WebSite = FakeData.NetworkData.GetDomain();
                    prd.Movies = LSTFilm;

                    LSTPrd.Add(prd);
                    _serviceProducer.Insert(prd);
                }
                Newfilm.Producers = LSTPrd;

                LSTFilm.Add(Newfilm);
                _serviceFilm.Insert(Newfilm);
            }

            for (int i = 0; i < 5; i++)
            {
                User usr = new User();
                usr.Name = FakeData.NameData.GetFirstName();
                usr.Surname = FakeData.NameData.GetSurname();
                usr.BirthDate = FakeData.DateTimeData.GetDatetime();
                usr.Email = FakeData.NetworkData.GetEmail();
                usr.ImagePath = "../../images/gridallbum" + FakeData.TextData.GetNumeric(1) + ".jpg";
                usr.Password = "123";
                usr.Role = (ProjectTemplate.Core.Enums.Role)(rd.Next(0, 1));
                _serviceUser.Insert(usr);
            }

            MessageBox.Show("Veri Eklendi");
            dataGridView1.DataSource = _serviceFilm.GetAll();
        }
    }
}
