﻿namespace TestProject
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SoccerContext : DbContext
    {
        // Контекст настроен для использования строки подключения "SoccerContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "TestProject.SoccerContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "SoccerContext" 
        // в файле конфигурации приложения.
        public SoccerContext()
            : base("name=SoccerContext")
        {
        }       

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}