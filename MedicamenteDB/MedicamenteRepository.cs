using MedicamenteDB.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace MedicamenteDB
{
    public class MedicamenteRepository
    {
        public void Add(MedicamenteModel medicament)
        {
            using (var db = new LiteDatabase(@"c:\temp\MedicamenteDB.db"))
            {
                // Get customer collection
                var Medicamente = db.GetCollection< MedicamenteModel>("medicamente");

                Medicamente.Insert(medicament);
            }
            
        }

        public List<MedicamenteModel> GetAll()
        {
            try
            {
                using (var db = new LiteDatabase(@"c:\temp\MedicamenteDB.db"))
                {
                    // Get customer collection
                    var MedicamenteDB = db.GetCollection<MedicamenteModel>("Medicamente");

                    return MedicamenteDB.FindAll().ToList();
                }
            }catch(Exception ex)
            {
                //log exceptions

                throw new ApplicationException("Eroare la conectarea la baza de date", ex);
            }
        }

        public void Delete(int id)
        {
            var db = new LiteDatabase(@"c:\temp\MedicamenteDB.db");
            var medicamente = db.GetCollection<MedicamenteModel>("Medicamente");

            medicamente.Delete(id);

        }

        public List<MedicamenteModel> Search(string text)
        {
            var db = new LiteDatabase(@"c:\temp\\MedicamenteDB.db");
            var medicamente = db.GetCollection<MedicamenteModel>("medicamente");

            return medicamente.Find(
                    Query.Or(
                        Query.Contains("Name", text) 
                        
                    )
                ).ToList();
        }
    }
}