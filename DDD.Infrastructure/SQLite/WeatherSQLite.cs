using DDD.Domain;
using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DDD.Infrastructure.SQLite
{
    public class WeatherSQLite : IWeatherRepository
    {
        public WeatherEntity GetLatest(int areaId)
        {
            var sql = @"
select 
    AreaId, 
    DataDate, 
    Condition, 
    Temperature 
from 
    Weather 
where 
    AreaId = @AreaId 
order by 
    DataDate desc 
LIMIT 1";

            return SQLiteHelper.QuerySingle(sql,
                new List<SQLiteParameter> {
                    new SQLiteParameter("@AreaId",areaId)
                }.ToArray(),
                reader => new WeatherEntity(
                            Convert.ToInt32(reader["AreaId"]),
                            Convert.ToDateTime(reader["DataDate"]),
                            Convert.ToInt32(reader["Condition"]),
                            Convert.ToSingle(reader["Temperature"])
                            ),
                null);

        }
    }
}
