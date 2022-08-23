using UseADO.Modals;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseADO.DataAccess
{
    internal class CustomerDAO
    {
        private static List<Customer> ConvertToListCustomer(DataTable dt)
        {
            List<Customer> cus = new List<Customer>();
            foreach (DataRow dr in dt.Rows)
            {
                cus.Add(new Customer(
                    dr[0].ToString(),
                    dr[1].ToString(),
                    dr[2].Equals(true) ? "Male" : "Female",
                    dr[3].ToString(),
                    Convert.ToDateTime(dr[4])
                    ));
            }
            return cus;
        }

        private static Customer ConvertToCustomer(DataTable dt)
        {
            Customer cus = new Customer();
            foreach (DataRow dr in dt.Rows)
            {
                   cus =  new Customer(
                    dr[0].ToString(),
                    dr[1].ToString(),
                    dr[2].Equals(true) ? "Male" : "Female",
                    dr[3].ToString(),
                    Convert.ToDateTime(dr[4])
                    );
            }
            return cus;
        }


        public static List<Customer> GetAllCustomer()
        {
            string sql = "select * from tblKhachHang";
            DataTable dt = DAO.GetDataBySql(sql, null);
            //dt -> List<Student>
            return ConvertToListCustomer(dt);
        }

        //public static List<Major> GetAllMajors()
        //{
        //    string sql = "select * from Major";
        //    DataTable dt = DAO.GetDataBySql(sql, null);
        //    return ConvertToListMajors(dt);
        //}

        //public static List<Major> GetMajors()
        //{
        //    string sql = "select * from Major";
        //    DataTable dt = DAO.GetDataBySql(sql, null);
        //    return ListMajors(dt);
        //}

        public static Customer GetCustomerById(string id)
        {
            string sql = "select * from tblKhachHang where MaKH = @id";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@id", SqlDbType.VarChar);
            parameter[0].Value = id;
            DataTable dt = DAO.GetDataBySql(sql, parameter);
            return ConvertToCustomer(dt);
        }

        public static List<Customer> GetListCustomerById(string id)
        {
            string sql = "select * from tblKhachHang where MaKH = @id";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@id", SqlDbType.VarChar);
            parameter[0].Value = id;
            DataTable dt = DAO.GetDataBySql(sql, parameter);
            return ConvertToListCustomer(dt);
        }

        public static List<Customer> GetListCustomerByname(string name)
        {
            string sql = "select * from tblKhachHang where TenKH like @name ";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@name", SqlDbType.VarChar);
            parameter[0].Value = $"%{name}%" ;
            DataTable dt = DAO.GetDataBySql(sql, parameter);
            return ConvertToListCustomer(dt);
        }

        //public static int checkExistStudent(int id)
        //{
        //    string sql = "select count(*) from Students where id = @id";
        //    SqlParameter[] parameter = new SqlParameter[1];
        //    parameter[0] = new SqlParameter("@id", SqlDbType.VarChar);
        //    parameter[0].Value = id;
        //    return Convert.ToInt32(DAO.GetDataBySql(sql, parameter).Rows[0][0].ToString());
        //}

        //public static int insertStudent(Student student)
        //{
        //    string sql = "insert into  Students values (@id, @name, @gender, @dob, @major, @active, @scholarship)";
        //    SqlParameter[] parameter = new SqlParameter[7];
        //    parameter[0] = new SqlParameter("@id", SqlDbType.Int);
        //    parameter[0].Value = student.Id;
        //    parameter[1] = new SqlParameter("@name", SqlDbType.VarChar);
        //    parameter[1].Value = student.Name;
        //    parameter[2] = new SqlParameter("@gender", SqlDbType.Bit);
        //    parameter[2].Value = student.Gender.Equals("Male") ? 0 : 1;
        //    parameter[3] = new SqlParameter("@dob", SqlDbType.Date);
        //    parameter[3].Value = student.DOB;
        //    parameter[4] = new SqlParameter("@major", SqlDbType.VarChar);
        //    parameter[4].Value = student.Major.Code;
        //    parameter[5] = new SqlParameter("@active", SqlDbType.Bit);
        //    parameter[5].Value = student.Active ? 1 : 0;
        //    parameter[6] = new SqlParameter("@scholarship", SqlDbType.Int);
        //    parameter[6].Value = student.Scholarship;
        //    return DAO.ExecuteSql(sql, parameter);
        //}

        public static int updateCus(string id, string name, string address, string dob, int gender)
        {
            string sql = "update tblKhachHang set TenKH = @name, Diachi = @address, NgaySinh = @dob, GT = @gender where MaKH = @id";
            SqlParameter[] parameter = new SqlParameter[5];
            parameter[0] = new SqlParameter("@name", SqlDbType.NVarChar);
            parameter[0].Value = name;
            parameter[1] = new SqlParameter("@address", SqlDbType.NVarChar);
            parameter[1].Value = address;
            parameter[2] = new SqlParameter("@dob", SqlDbType.DateTime);
            parameter[2].Value = dob;
            parameter[3] = new SqlParameter("@gender", SqlDbType.Bit);
            parameter[3].Value = gender;
            parameter[4] = new SqlParameter("@id", SqlDbType.VarChar);
            parameter[4].Value = id;
            return DAO.ExecuteSql(sql, parameter);
        }

        //public static int editStudent(Student student)
        //{
        //    string sql = "update Students set name = @name, gender = @gender, dob = @dob, major = @major, active = @active, scholarship = @scholarship where id = @id";
        //    SqlParameter[] parameter = new SqlParameter[7];
        //    parameter[0] = new SqlParameter("@name", SqlDbType.VarChar);
        //    parameter[0].Value = student.Name;
        //    parameter[1] = new SqlParameter("@gender", SqlDbType.Bit);
        //    parameter[1].Value = student.Gender.Equals("Male") ? 0 : 1;
        //    parameter[2] = new SqlParameter("@dob", SqlDbType.Date);
        //    parameter[2].Value = student.DOB;
        //    parameter[3] = new SqlParameter("@major", SqlDbType.VarChar);
        //    parameter[3].Value = student.Major.Code;
        //    parameter[4] = new SqlParameter("@active", SqlDbType.Bit);
        //    parameter[4].Value = student.Active ? 1 : 0;
        //    parameter[5] = new SqlParameter("@scholarship", SqlDbType.Int);
        //    parameter[5].Value = student.Scholarship;
        //    parameter[6] = new SqlParameter("@id", SqlDbType.Int);
        //    parameter[6].Value = student.Id;
        //    return DAO.ExecuteSql(sql, parameter);
        //}
    }
}
