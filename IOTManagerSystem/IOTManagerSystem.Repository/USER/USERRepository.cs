﻿using IOTManagerSystem.Model.USER;
using IOTManagerSystem.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using IOTManagerSystem.Model.ACCOUNT;

namespace IOTManagerSystem.Repository.USER
{
    public class USERRepository : BaseRepository, IUSERRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<USERModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public USERModel GetById(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("id", id);

            IEnumerable<USERModel> temp = Query<USERModel>(@"SELECT [USER].id, ma_nguoi_dung, ho_ten_nguoi_dung, sdt, cmnd,
		                                                            email, dia_chi, avartar, ngay_sinh, noi_sinh, id_role, ten_role
                                                            FROM dbo.[USER],dbo.ROLE
                                                            WHERE [USER].id = @id AND ROLE.id = id_role", 
                                                            CommandType.Text, param);
            if (temp.Count() > 0)
                return temp.First();
            return null;
        }

        public bool Insert(USERModel model)
        {
            throw new NotImplementedException();
        }

        public bool Update(USERModel model)
        {
            throw new NotImplementedException();
        }

        public USERModel GetUSERByIdAccount(ACCOUNTModel account)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("id", account.id);

            IEnumerable<USERModel> temp = Query<USERModel>(@"SELECT DISTINCT [USER].id, ma_nguoi_dung, ho_ten_nguoi_dung, sdt, cmnd,
		                                                            email, dia_chi, avartar, ngay_sinh, noi_sinh, id_role,ma_role, ten_role
                                                            FROM dbo.ACCOUNT, dbo.[USER], dbo.ROLE
                                                            WHERE id_ma_nguoi_dung = [USER].id AND id_role = ROLE.id
		                                                            AND ACCOUNT.id = @id",
                                                            CommandType.Text, param);
            if (temp.Count() > 0)
                return temp.First();
            return null;
        }
    }
}
