using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApp1
{
    public struct PictureData
    {
        public int id;
        public string path;
    }
    public static class RequestsSQLT
    {
        public static List<PictureData> photosList = new List<PictureData>();
        public static List<string> comboElements = new List<string>();
        public static DataTable ApplyTargetFiltres(SqlConnection connection, string type, DateTime b1, DateTime b2, int bp, int tp)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand();
            if (type != null)
            {
                //command = new SqlCommand($"SELECT a.number, a.type, a.price, l.settling, l.eviction FROM Apartments a, Living l, Booking b WHERE (a.type={type} AND b.settling>'{b2}' AND l.eviction<'{b1}' AND a.price>{bp} AND a.price<{tp})", connection);
                command = new SqlCommand($"SELECT a.number, a.\"type\", a.price FROM Apartments a WHERE a.\"type\" = '{type}' AND a.price > {bp} AND a.price < {tp} AND ((a.number IN (SELECT number FROM Living WHERE eviction < '{b1}') AND NOT EXISTS(SELECT number FROM Booking WHERE a.number IN (SELECT number FROM Booking))) OR (a.number in (SELECT number FROM Booking WHERE settling > '{b2}') OR (a.number in (SELECT number FROM Booking WHERE eviction < '{b1}'))) AND NOT EXISTS(SELECT number FROM Living WHERE a.number IN (SELECT number FROM Living)) OR ((a.number in (SELECT number FROM Living WHERE eviction<'{b1}')) AND (a.number in (SELECT number FROM Booking WHERE settling>'{b2}') OR (a.number in (SELECT number FROM Booking WHERE eviction<'{b1}')))) OR (a.number NOT IN (SELECT number FROM Living) AND a.number NOT IN (SELECT number FROM Booking)))", connection);
            }
            else
            {
                //command = new SqlCommand($"SELECT a.number, a.type, a.price, l.settling, l.eviction FROM Apartments a, Living l, Booking b WHERE (b.settling>'{b2}' AND l.eviction<'{b1}' AND a.price>{bp} AND a.price<{tp})", connection);
                command = new SqlCommand($"SELECT a.number, a.\"type\", a.price FROM Apartments a WHERE a.price > {bp} AND a.price < {tp} AND ((a.number IN (SELECT number FROM Living WHERE eviction < '{b1}') AND NOT EXISTS(SELECT number FROM Booking WHERE a.number IN (SELECT number FROM Booking))) OR (a.number in (SELECT number FROM Booking WHERE settling > '{b2}') OR (a.number in (SELECT number FROM Booking WHERE eviction < '{b1}'))) AND NOT EXISTS(SELECT number FROM Living WHERE a.number IN (SELECT number FROM Living)) OR ((a.number in (SELECT number FROM Living WHERE eviction<'{b1}')) AND (a.number in (SELECT number FROM Booking WHERE settling>'{b2}') OR (a.number in (SELECT number FROM Booking WHERE eviction<'{b1}')))) OR (a.number NOT IN (SELECT number FROM Living) AND a.number NOT IN (SELECT number FROM Booking)))", connection);
            }
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            return dt;
        }

        public static List<string> GetTypesOfApartments(List<string> cE, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand($"SELECT DISTINCT type FROM Apartments", connection);
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cE.Add(reader.GetValue(0).ToString());
                }
            }
            reader.Close();
            return cE;
        }
        public static List<PictureData> CollectImagesOfNthNumber(SqlConnection connection, int nOA, List<PictureData> pList)
        {
            pList.Clear();
            SqlCommand command = new SqlCommand($"SELECT photos_id, path FROM Photos WHERE number = {nOA}", connection);
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    pList.Add(new PictureData() { id = Convert.ToInt32(reader.GetValue(0)), path = reader.GetValue(1).ToString()});
                }
            }
            reader.Close();
            return pList;
        }

        public static bool SelectSetValueOfNumberFromApartments(TextBox tb, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand($"SELECT DISTINCT number FROM Apartments WHERE number = {Convert.ToInt32(tb.Text)}", connection);
            command.CommandType = CommandType.Text;
            if (command.ExecuteScalar() == null)
            {
                MessageBox.Show("Введён не существующий номер");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static DataTable SelectAllFromCustomer(SqlConnection connection)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand("SELECT passport_series, passport_number, name, surname, patronymic, birthday, tel_number FROM Customer", connection);
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            return dt;
        }
        public static DataTable SelectAllFromCustomerWithSetSurname(SqlConnection connection, TextBox tb)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand($"SELECT passport_series, passport_number, name, surname, patronymic, birthday, tel_number FROM Customer WHERE surname LIKE '{tb.Text}%'", connection);
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            return dt;
        }
        public static string SelectNthIdFromCustomerToString(SqlConnection connection, int n)
        {
            SqlCommand command = new SqlCommand($"SELECT DISTINCT customer_id FROM Customer WHERE customer_id = {n}", connection);
            command.CommandType = CommandType.Text;
            return command.ExecuteScalar().ToString();
        }
        public static string SelectNthIdFromCustomerWherePassportDataDefinedToString(SqlConnection connection, int ps, int pn)
        {
            SqlCommand command = new SqlCommand($"SELECT DISTINCT customer_id FROM Customer WHERE passport_series = {ps} AND passport_number = {pn}", connection);
            command.CommandType = CommandType.Text;
            if(command.ExecuteScalar() == null)
            {
                return "null";
            }
            else
            {
                return command.ExecuteScalar().ToString();
            }
        }
        public static DataTable SelectAllFromCustomerByCustomerId(SqlConnection connection, int iOC)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand($"SELECT passport_series, passport_number, name, surname, patronymic, birthday, tel_number FROM Customer WHERE customer_id = {iOC}", connection);
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            return dt;
        }
        public static DataTable SelectAllFromLiving(SqlConnection connection)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand("SELECT c.passport_series, c.passport_number, c.name, c.surname, c.patronymic, l.settling, l.eviction, l.number, l.value_of_guests, l.value_of_kids, l.as_id, l.living_id FROM Customer c, Living l WHERE c.customer_id = l.customer_id", connection);
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            return dt;
        }
        public static DataTable SelectAllFromLivingByCustomerId(SqlConnection connection, int iOC)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand($"SELECT c.passport_series, c.passport_number, c.name, c.surname, c.patronymic, l.settling, l.eviction, l.number, l.value_of_guests, l.value_of_kids, l.as_id, l.living_id FROM Customer c, Living l WHERE l.customer_id = {iOC} AND c.customer_id = {iOC}", connection);
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            return dt;
        }
        public static DataTable SelectAllFromBooking(SqlConnection connection)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand("SELECT c.passport_series, c.passport_number, c.name, c.surname, c.patronymic, b.settling, b.eviction, b.number, b.value_of_guests, b.value_of_kids, b.booking_id, b.booking_id FROM Customer c, Booking b WHERE c.customer_id = b.customer_id", connection);
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            return dt;
        }
        public static DataTable SelectAllFromBookingByCustomerId(SqlConnection connection, int iOC)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand($"SELECT c.passport_series, c.passport_number, c.name, c.surname, c.patronymic, b.settling, b.eviction, b.number, b.value_of_guests, b.value_of_kids, b.booking_id, b.booking_id FROM Customer c, Booking b WHERE b.customer_id = {iOC} AND c.customer_id = {iOC}", connection);
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            return dt;
        }
        public static DataTable SelectAllFromApartments(SqlConnection connection)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand($"SELECT number, type, price FROM Apartments", connection);
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            return dt;
        }
        public static DataTable SelectAllFromApartmentsWhereNumberIsSet(SqlConnection connection, int n)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand($"SELECT number, type, price FROM Apartments WHERE number = {n}", connection);
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            return dt;
        }
        public static bool ApartmentConsistsSomePhotos(SqlConnection connection, int nOA)
        {
            SqlCommand command = new SqlCommand($"SELECT number, type, price FROM Apartments WHERE number = {nOA}", connection);
            command.CommandType = CommandType.Text;
            if (command.ExecuteScalar() == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool NumberOfApartmentsIsFree(SqlConnection connection, int nOA)
        {
            SqlCommand command = new SqlCommand($"SELECT a.number FROM Apartments a WHERE (a.number = {nOA}) AND ((a.number IN (SELECT number FROM Living WHERE eviction < '{DateTime.Today}') AND NOT EXISTS(SELECT number FROM Booking WHERE a.number IN (SELECT number FROM Booking))) OR ((a.number in (SELECT number FROM Booking WHERE eviction < '{DateTime.Today}'))) AND NOT EXISTS(SELECT number FROM Living WHERE a.number IN (SELECT number FROM Living)) OR ((a.number in (SELECT number FROM Living WHERE eviction<'{DateTime.Today}')) AND ((a.number in (SELECT number FROM Booking WHERE eviction<'{DateTime.Today}')))) OR (a.number NOT IN (SELECT number FROM Living) AND a.number NOT IN (SELECT number FROM Booking)))", connection);
            command.CommandType = CommandType.Text;
            if (command.ExecuteScalar() == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsNotThereSetNumberInApartments(SqlConnection connection, int nOA)
        {
            SqlCommand command = new SqlCommand($"SELECT DISTINCT number FROM Apartments WHERE number = {nOA}", connection);
            command.CommandType = CommandType.Text;
            if (command.ExecuteScalar() == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ComapreCustomerFIOforOneID(SqlConnection connection, int pSeries, int pNumber, string n, string s, string p)
        {
            string[] fio = new string[3];
            SqlCommand command = new SqlCommand($"SELECT DISTINCT name, surname, patronymic FROM Customer WHERE passport_series = {pSeries} AND passport_number = {pNumber}", connection);
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                fio[0] = reader.GetValue(0).ToString();
                fio[1] = reader.GetValue(1).ToString();
                fio[2] = reader.GetValue(2).ToString();
            }
            if (n == fio[0] && s == fio[1] && p == fio[2])
            {
                reader.Close();
                return true;
            }
            reader.Close();
            return false;
        }
        public static int ValueOfCustomerLivingsAndBookingsForToday(SqlConnection connection, int iOC)
        {
            SqlCommand command1 = new SqlCommand($"SELECT COUNT(l.living_id) FROM Living l WHERE l.eviction>'{DateTime.Today}' AND l.customer_id IN (SELECT customer_id FROM Customer WHERE customer_id = {iOC})",Form1.conn);
            SqlCommand command2 = new SqlCommand($"SELECT COUNT(b.booking_id) FROM Booking b WHERE b.customer_id IN (SELECT customer_id FROM Customer WHERE customer_id = {iOC})",Form1.conn);
            int v = Convert.ToInt32(command1.ExecuteScalar())+Convert.ToInt32(command2.ExecuteScalar());
            return v;
            //DateTime.Today;
        }
        public static int GetCurrentDiscount(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand($"SELECT DISTINCT discount FROM Discount", connection);
            command.CommandType = CommandType.Text;
            if (command.ExecuteScalar() == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        public static void SetNewDiscount(SqlConnection connection, int disc)
        {
            SqlCommand command0 = new SqlCommand($"SELECT DISTINCT discount FROM Discount", connection);
            command0.CommandType = CommandType.Text;
            if (command0.ExecuteScalar() == null)
            {
                SqlCommand command1 = new SqlCommand($"INSERT INTO Discount (discount) VALUES ({disc})", connection);
                command1.ExecuteNonQuery();
            }
            else
            {
                SqlCommand command2 = new SqlCommand($"UPDATE Discount SET discount = {disc}", connection);
                command2.ExecuteNonQuery();
            }
        }
        public static int[] SelectAllFromAdditionalServicesWhereIsSetLivingID(SqlConnection connection, int iOL)
        {
            int[] v = new int[5];
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand($"SELECT mini_bar, clothes_washing, telephone, intercity_telephone, food FROM Additional_services WHERE as_id = {iOL}", connection);
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    for (int i = 0; i < v.Length; i++)
                    {
                        if (reader.GetValue(i) == null)
                        {
                            v[i] = 0;
                        }
                        else
                        {
                            v[i] = Convert.ToInt32(reader.GetValue(i));
                        }
                    }
                }
            }
            reader.Close();
            return v;
        }
        public static bool DoesCustomerHasNoLivivngsAndBookings(SqlConnection connection, int iOC)
        {
            SqlCommand command1 = new SqlCommand($"SELECT living_id FROM Living WHERE customer_id = {iOC}", connection);
            command1.CommandType = CommandType.Text;
            SqlCommand command2 = new SqlCommand($"SELECT booking_id FROM Booking WHERE customer_id = {iOC}", connection);
            command2.CommandType = CommandType.Text;
            if (command1.ExecuteScalar() == null && command2.ExecuteScalar() == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
