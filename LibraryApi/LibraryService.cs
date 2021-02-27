using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LibraryApi
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class LibraryService : ILibraryService
    {
        #region FunToModifyAddEditCustomers

        public string AddClientToDatabase(Klienci client)
        {
            var context = new libraryEntities();

            context.Kliencis.Add(client);
            context.SaveChanges();

            return "Dodano Klienta";
        }

        public void ModifyClient(Klienci client)
        {
            var context = new libraryEntities();
            var person = context.Kliencis.Find(client.IDKlienta);
            person.Imie = client.Imie;
            person.Nazwisko = client.Nazwisko;
            person.Plec = client.Plec;
            person.Wiek = client.Wiek;
            person.Email = client.Email;
            person.Telefon = client.Telefon;
            context.SaveChanges();
        }
        public void DeleteClientAfterID(int index)
        {
            var context = new libraryEntities();
            var person = context.Kliencis.Where(e => e.IDKlienta == index).FirstOrDefault();
            context.Kliencis.Remove(person);
            context.SaveChanges();
        }
        public Klienci GetLastClient()
        {
            var context = new libraryEntities();
            var klient = context.Kliencis.OrderByDescending(el => el.IDKlienta).FirstOrDefault();
            return klient;
        }

        public Klienci FetchClientAfterID(int index)
        {
            var context = new libraryEntities();
            var klient = context.Kliencis.Where(e => e.IDKlienta == index).FirstOrDefault();
            return klient;
        }
        public IEnumerable<Klienci> GetAllClient()
        {
            var context = new libraryEntities();
            return context.Kliencis;
        }

        #endregion


        #region FunToModifyAddEditBooks
        public IEnumerable<Ksiazka> GetAllBooks()
        {
            var context = new libraryEntities();
            return context.Ksiazkas;
        }
        #endregion

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
