using MedicamenteDB.Models;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;



namespace MedicamenteDB
{
    public class Repository__
    {
        const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";


        const string GetAllMedicamentQuery = "Select * From Medicamente";
        const string InsertMedicamentQuery = @"INSERT INTO Medicamente (Name, Category, Dosage, Form)
            VALUES(@name, @category, @dosage, @form);";
        const string DelteMedicamentQuery = @"Delete From Medicamente where Id = @id";

        public List<MedicamenteModel> GetMedicamente()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString;


            SqlCommand command = new SqlCommand(GetAllMedicamentQuery, connection);
            //command.Parameters.AddWithValue("@pricePoint", paramValue);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<MedicamenteModel> medicamenteList = new List<MedicamenteModel>();

            while (reader.Read())
            {
                MedicamenteModel Medicament = new MedicamenteModel();
                Medicament.Id = reader.GetInt32(0);
                Medicament.Name = reader.GetString(1);
                

                medicamenteList.Add(Medicament);
            }

            reader.Close();

            connection.Close();

            return medicamenteList;
        }

        public void AddBook(MedicamenteModel medicament)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString;


            SqlCommand command = new SqlCommand(InsertMedicamentQuery, connection);
            command.Parameters.Add("@name", SqlDbType.VarChar).Value =medicament.Name;
         

            connection.Open();
            command.ExecuteNonQuery();
            
            connection.Close();
        }

        public void DeleteMedicament(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString;

            SqlCommand command = new SqlCommand(DelteMedicamentQuery, connection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}