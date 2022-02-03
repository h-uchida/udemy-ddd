using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DDD.Infrastructure.SQLite
{
    public sealed class AreasSQLite : IAreasRepository
    {
        public IReadOnlyList<AreaEntity> GetData()
        {
            var sql = @"
Select 
    AreaId, 
    AreaName
From
    Areas";

            return SQLiteHelper.Query(
                sql,
                reader => new AreaEntity(
                    Convert.ToInt32(reader["AreaId"]),
                    Convert.ToString(reader["AreaName"])
                )
                );
        }
    }
}
