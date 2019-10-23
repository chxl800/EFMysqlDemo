using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFMysqlFrameWork.Common;
using EFMysqlFrameWork.Model;
using Json.Net;

namespace EFMysqlFrameWork
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseDAL<User> dal = new BaseDAL<User>();


            User user = new User();
            user.Id = Guid.NewGuid().ToString().Replace("-","");
            dal.Add(user);
            dal.SaveChanges();

            List<User> list = dal.QueryWhere(s => true);

            //json转化
            var userJson = JsonNet.Serialize(list, JsonHelper.dateConverter);
            //var userList = JsonNet.Deserialize<List<User>>(userJson, JsonHelper.dateConverter);

            Console.WriteLine(userJson);
            Console.Read();
        }
    }



}
