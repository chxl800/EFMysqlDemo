using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFMysqlNetCode.Common;
using EFMysqlNetCode.Model;
using Json.Net;

namespace EFMysqlNetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            DBEntities db = new DBEntities();

            //新增
            User user = new User();
            user.Id = Guid.NewGuid().ToString().Replace("-", "");
            db.User.Add(user);
            db.SaveChanges();

            //查询
            List<User> list= db.User.ToList();

            //json转化
            var userJson = JsonNet.Serialize(list, JsonHelper.dateConverter);
            //var userList = JsonNet.Deserialize<List<User>>(userJson, JsonHelper.dateConverter);


            Console.WriteLine(userJson);
            Console.Read();
        }
    }



}
