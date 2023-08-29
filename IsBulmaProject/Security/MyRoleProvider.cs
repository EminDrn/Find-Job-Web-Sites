using IsBulmaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;


namespace IsBulmaProject.Security
{
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            IsBulmaEntities model = new IsBulmaEntities();
            Console.WriteLine(username);
            var userroles = new List<string>();
            
            // kullanıcının rollerini kullanici tablosundan al
            Kullanici kullanici = model.Kullanici.FirstOrDefault(u => u.Mail == username);
            if (kullanici != null)
            {
                string role = kullanici.RoleID.ToString();
                userroles.Add(role);
            }

            // kullanıcının rollerini isverenkayit tablosundan al
            IsVerenKayit isveren = model.IsVerenKayit.FirstOrDefault(v => v.isVerenSirketAdi == username);
            if (isveren != null)
            {
                string role = isveren.RoleID.ToString();
                
                userroles.Add(role);
            }

            return userroles.Distinct().ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}