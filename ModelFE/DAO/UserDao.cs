using ModelFE.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFE.DAO
{
    public class UserDao
    {
        private EF.DoanNgocPhuQuocContext db = null;
        public UserDao()
        {
            db = new EF.DoanNgocPhuQuocContext();
        }
        //Check login
        public int login(string user, string pass)
        {
            var result = db.UserAccount.SingleOrDefault(x => x.UserName.Contains(user) && x.Password.Contains(pass));
            if (result == null)
                return 0;
            else
                return 1;
        }
        //Hàm xử lí Insert trong UserDao 
        public string Insert(UserAccount entityUser)
        {
            var user = Find(entityUser.UserName);
            if (user == null)
            {
                db.UserAccount.Add(entityUser);
            }
            else
            {
                user.IDAcc = entityUser.IDAcc;
                user.UserName = entityUser.UserName;
                user.Password = entityUser.Password;
                user.Status = entityUser.Status;
            }
            db.SaveChanges();

            return entityUser.UserName;
        }

        //Hàm kiểm tra Username nhập vào có trùng không
        public UserAccount Find(string username)
        {

            return db.UserAccount.Find(username); 
        }
        //Tra ve danh sach nguoi dung
        public List<UserAccount> ListAll()
        {
            return db.UserAccount.ToList();
        }
        //Kiem tra xoa
        public bool Delete(string username)
        {
            try
            {
                var user = Find(username);
                db.UserAccount.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //tìm kiếm ngươi dùng thông qua keyserach 
        public IEnumerable<UserAccount> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<UserAccount> model = db.UserAccount;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.UserName.Contains(keysearch));
            }
            return model.OrderBy(x => x.UserName).ToPagedList(page, pagesize);
        }
    }
}
