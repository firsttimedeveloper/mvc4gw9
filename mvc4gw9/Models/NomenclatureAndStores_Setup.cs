﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace mvc4gw9.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Nomenclature> Nomenclature { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<FeaturesSet> FeaturesSets { get; set; }
        public DbSet<NomenclatureView> NomenclatureViews { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<FeaturesOfNomenclature> FeaturesOfNomenclatures { get; set; }
        public DbSet<NomenclatureInStore> NomenclatureInStores { get; set; }
    }

    public class DBInitializer : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            List<Group> groups = new List<Group>() {
                new Group {Id=1, Name="Каталог", ParentGroupId = 1},
                new Group {Id=2, Name="Детская", ParentGroupId = 1},
                new Group {Id=3, Name="Мужская", ParentGroupId = 1},
                new Group {Id=4, Name="Женская", ParentGroupId = 1},                
                
                new Group {Id=5, Name="Обувь", ParentGroupId = 2},
                new Group {Id=6, Name="Dockers", ParentGroupId = 5},
                new Group {Id=7, Name="TomTailor", ParentGroupId = 5},
                new Group {Id=8, Name="sOliver", ParentGroupId = 5},
                
                new Group {Id=9, Name="Зимняя одежда", ParentGroupId = 2},
                
                new Group {Id=10, Name="Куртки", ParentGroupId = 9},                
                new Group {Id=11, Name="Exes", ParentGroupId = 10},
                new Group {Id=12, Name="Scout", ParentGroupId = 10},
                new Group {Id=13, Name="Arizona", ParentGroupId = 10},

                new Group {Id=14, Name="Брюки", ParentGroupId = 9},                                
                new Group {Id=15, Name="Scout", ParentGroupId = 14},

            };
            groups.ForEach(x => context.Groups.Add(x));
            context.SaveChanges();
            
            List<Nomenclature> nomenclature = new List<Nomenclature>() {
                new Nomenclature {Id=1, GroupId=6, Name="Dockers", Description="Спортивные ботинки - отлично подходят для зимы. Из искусственной кожи с отделкой Dock-Tex. Теплая внутренняя отделка. Износостойкая подошва из синтетики"},
                new Nomenclature {Id=2, GroupId=7, Name="Ботинки TomTailor", Description="В обуви для детей важно все: материал верха, внутренняя отделка, декоративное оформление. Оригинальная модель ботинок со шнуровкой от модного бренда Tom Tailor станет любимой..."},
                new Nomenclature {Id=3, GroupId=8, Name="sOliver", Description="Модные полусапожки от бренда s.Oliver придутся по вкусу настоящим модницам. Оригинальная модель в стиле кэжуал обладает максимальным комфортом. Удобство обуви обеспечивает..."},
                new Nomenclature {Id=4, GroupId=7, Name="Слипперы TomTailor", Description="Лицевой материал: брезент. Подкладка: текстиль. Стелька: текстиль. По бокам — эластичные вставки. Застежка: отсутствует"},
                new Nomenclature {Id=5, GroupId=7, Name="Ботинки TomTailor", Description="Искусственная кожа. Подкладка: сохраняет тепло. Стелька: текстиль. Технология TEX, мягкий воротник и дополнительная молния. Тип застежки: шнуровка"},
                new Nomenclature {Id=6, GroupId=6, Name="Ботинки на шнуровке Dockers", Description="Лицевой материал: брезент. Подкладка: текстиль. Стелька: текстиль. Тип застежки: шнуровка"},
                new Nomenclature {Id=7, GroupId=11, Name="Куртка-софтшелл Exes", Description="Модель выполнена из влаго- и ветронепроницаемого материала. С системой SOS. Манжеты на рукавах с отверстиями для больших пальцев. Со светоотражателями"},
                new Nomenclature {Id=8, GroupId=11, Name="Зимняя куртка Exes", Description="Система аварийной сигнализации SAFETY FIRST. Модель с эластичной съемной снегозащитной стекой. Водонепроницаемое изделие из дышащего материала. Съемный капюшон. Модель с оригинальным принтом"},
                new Nomenclature {Id=9, GroupId=12, Name="Лыжная куртка Scout", Description="Очень тёплый и лёгкий материал. Суперцена. Отражатели. С защитой от ветра на рукавах и по нижнему краю. Отстёгивающийся капюшон с подкладкой из флиса"},
                new Nomenclature {Id=10, GroupId=12, Name="Лыжная куртка Scout", Description="Капюшон с подкладкой из флиса можно отстегнуть. Со светоотражателями со всех сторон. Всепогодный материал. Защита от ветра на рукавах и снизу. Модель со съемным капюшоном на мягкой флисовой подкладке"},
                new Nomenclature {Id=11, GroupId=13, Name="Стеганая куртка Arizona", Description="Стеганая куртка с капюшоном от Arizona. Теплая подкладка. Контрастные молнии. Машинная стирка"},
                new Nomenclature {Id=12, GroupId=15, Name="Лыжные брюки Scout", Description="Для настоящего скаута. Великолепные лыжные брюки с регулируемыми съёмными бретельками. Эластичный пояс, втачной карман с застёжкой на молнию. Разрез с застёжкой-липучкой снизу, защита от ветра. С небольшой вышивкой «Scout»"},
            };
            nomenclature.ForEach(x => context.Nomenclature.Add(x));
            context.SaveChanges();

            List<FeaturesSet> featuressets = new List<FeaturesSet>() {
                new FeaturesSet {Id=1, Name="brown 40"},
                new FeaturesSet {Id=2, Name="brown 41"},
                new FeaturesSet {Id=3, Name="yellow 40"}, 
                new FeaturesSet {Id=4, Name="yellow 41"},
                new FeaturesSet {Id=5, Name="white 40"},
                new FeaturesSet {Id=6, Name="black 40"},
                new FeaturesSet {Id=7, Name="red 40"},
                new FeaturesSet {Id=8, Name="gray 40"},
                new FeaturesSet {Id=9, Name="black 41"},
                new FeaturesSet {Id=10, Name="brown 39"},
                
                new FeaturesSet {Id=11, Name="gray 38"},
                new FeaturesSet {Id=12, Name="gray 39"},
                new FeaturesSet {Id=13, Name="gray 41"},
                
                new FeaturesSet {Id=14, Name="blue-green 116/122"},
                new FeaturesSet {Id=15, Name="blue-green 128/134"},
                new FeaturesSet {Id=16, Name="blue-green 140/146"},
                new FeaturesSet {Id=17, Name="blue-green 152/158"},
                
                new FeaturesSet {Id=18, Name="blue-red 116/122"},
                new FeaturesSet {Id=19, Name="blue-red 128/134"},
                new FeaturesSet {Id=20, Name="blue-red 140/146"},
                new FeaturesSet {Id=21, Name="blue-red 164/170"},
                
                new FeaturesSet {Id=22, Name="green 128/134"},
                new FeaturesSet {Id=23, Name="green 140/146"},
                new FeaturesSet {Id=24, Name="green 152/158"},
                
                new FeaturesSet {Id=25, Name="blue-gray 128"},
                new FeaturesSet {Id=26, Name="blue-gray 134"},
                new FeaturesSet {Id=27, Name="blue-gray 140"},
                new FeaturesSet {Id=28, Name="blue-gray 146"},
                new FeaturesSet {Id=29, Name="blue-gray 152"},
                new FeaturesSet {Id=30, Name="blue-gray 158"},
                new FeaturesSet {Id=31, Name="blue-gray 164"},

                new FeaturesSet {Id=32, Name="orange-black 122"},
                new FeaturesSet {Id=33, Name="orange-black 128"},
                new FeaturesSet {Id=34, Name="orange-black 134"},
                new FeaturesSet {Id=35, Name="orange-black 140"},
                new FeaturesSet {Id=36, Name="orange-black 146"},
                new FeaturesSet {Id=37, Name="orange-black 152"},
                new FeaturesSet {Id=38, Name="orange-black 158"},
                new FeaturesSet {Id=39, Name="orange-black 164"},

                new FeaturesSet {Id=40, Name="green 128"},
                new FeaturesSet {Id=41, Name="green 134"},
                new FeaturesSet {Id=42, Name="green 140"},
                new FeaturesSet {Id=43, Name="green 146"},
                new FeaturesSet {Id=44, Name="green 152"},
                new FeaturesSet {Id=45, Name="green 158"},
                new FeaturesSet {Id=46, Name="green 164"},
                new FeaturesSet {Id=47, Name="green 170"},
                new FeaturesSet {Id=48, Name="green 176"},

                new FeaturesSet {Id=49, Name="violet 92"},
                new FeaturesSet {Id=50, Name="violet 98"},
                new FeaturesSet {Id=51, Name="violet 104"},
                new FeaturesSet {Id=52, Name="violet 110"},
                new FeaturesSet {Id=53, Name="violet 116"},
                new FeaturesSet {Id=54, Name="violet 122"},
                new FeaturesSet {Id=55, Name="violet 128"},
                new FeaturesSet {Id=56, Name="violet 134"},
                new FeaturesSet {Id=57, Name="violet 140"},
                new FeaturesSet {Id=58, Name="violet 146"},
                new FeaturesSet {Id=59, Name="violet 152"},
                new FeaturesSet {Id=60, Name="violet 158"},
                new FeaturesSet {Id=61, Name="violet 164"},
                
                new FeaturesSet {Id=62, Name="blue 92"},
                new FeaturesSet {Id=63, Name="blue 98"},
                new FeaturesSet {Id=64, Name="blue 104"},
                new FeaturesSet {Id=65, Name="blue 110"},
                new FeaturesSet {Id=66, Name="blue 116"},
                new FeaturesSet {Id=67, Name="blue 122"},
                new FeaturesSet {Id=68, Name="blue 128"},
                new FeaturesSet {Id=69, Name="blue 134"},
                new FeaturesSet {Id=70, Name="blue 140"},
                new FeaturesSet {Id=71, Name="blue 146"},
                new FeaturesSet {Id=72, Name="blue 152"},
                new FeaturesSet {Id=73, Name="blue 158"},
                new FeaturesSet {Id=74, Name="blue 164"},

                new FeaturesSet {Id=75, Name="red 92"},
                new FeaturesSet {Id=76, Name="red 98"},
                new FeaturesSet {Id=77, Name="red 104"},
                new FeaturesSet {Id=78, Name="red 110"},
                new FeaturesSet {Id=79, Name="red 116"},
                new FeaturesSet {Id=80, Name="red 122"},
                new FeaturesSet {Id=81, Name="red 128"},
                new FeaturesSet {Id=82, Name="red 134"},
                new FeaturesSet {Id=83, Name="red 140"},
                new FeaturesSet {Id=84, Name="red 146"},
                new FeaturesSet {Id=85, Name="red 152"},
                new FeaturesSet {Id=86, Name="red 158"},
                new FeaturesSet {Id=87, Name="red 164"},

                new FeaturesSet {Id=88, Name="gray 92"},
                new FeaturesSet {Id=89, Name="gray 98"},
                new FeaturesSet {Id=90, Name="gray 104"},
                new FeaturesSet {Id=91, Name="gray 110"},
                new FeaturesSet {Id=92, Name="gray 116"},
                new FeaturesSet {Id=93, Name="gray 122"},
                new FeaturesSet {Id=94, Name="gray 128"},
                new FeaturesSet {Id=95, Name="gray 134"},
                new FeaturesSet {Id=96, Name="gray 140"},
                new FeaturesSet {Id=97, Name="gray 146"},
                new FeaturesSet {Id=98, Name="gray 152"},
                new FeaturesSet {Id=99, Name="gray 158"},
                new FeaturesSet {Id=100, Name="gray 164"},

            };
            featuressets.ForEach(x => context.FeaturesSets.Add(x));
            context.SaveChanges();

            List<Characteristic> characteristics = new List<Characteristic>()
            {
                new Characteristic {Id=1, Name="color"},
                new Characteristic {Id=2, Name="size"}
            };
            characteristics.ForEach(x => context.Characteristics.Add(x));
            context.SaveChanges();

            List<FeaturesOfNomenclature> featuresofnumenclatures = new List<FeaturesOfNomenclature>()
            {
                new FeaturesOfNomenclature {Id=1, FeaturesSetId=1, CharacteristicId=1, Value="brown"},
                new FeaturesOfNomenclature {Id=2, FeaturesSetId=1, CharacteristicId=2, Value="40"},
                new FeaturesOfNomenclature {Id=3, FeaturesSetId=2, CharacteristicId=1, Value="brown"},
                new FeaturesOfNomenclature {Id=4, FeaturesSetId=2, CharacteristicId=2, Value="41"},

                new FeaturesOfNomenclature {Id=5, FeaturesSetId=3, CharacteristicId=1, Value="yellow"},
                new FeaturesOfNomenclature {Id=6, FeaturesSetId=3, CharacteristicId=2, Value="40"},
                new FeaturesOfNomenclature {Id=7, FeaturesSetId=4, CharacteristicId=1, Value="yellow"},
                new FeaturesOfNomenclature {Id=8, FeaturesSetId=4, CharacteristicId=2, Value="41"},

                new FeaturesOfNomenclature {Id=9, FeaturesSetId=5, CharacteristicId=1, Value="white"},
                new FeaturesOfNomenclature {Id=10, FeaturesSetId=5, CharacteristicId=2, Value="40"},

                new FeaturesOfNomenclature {Id=11, FeaturesSetId=6, CharacteristicId=1, Value="black"},
                new FeaturesOfNomenclature {Id=12, FeaturesSetId=6, CharacteristicId=2, Value="40"},

                new FeaturesOfNomenclature {Id=11, FeaturesSetId=7, CharacteristicId=1, Value="red"},
                new FeaturesOfNomenclature {Id=12, FeaturesSetId=7, CharacteristicId=2, Value="40"},

                new FeaturesOfNomenclature {Id=13, FeaturesSetId=8, CharacteristicId=1, Value="gray"},
                new FeaturesOfNomenclature {Id=14, FeaturesSetId=8, CharacteristicId=2, Value="40"},

                new FeaturesOfNomenclature {Id=15, FeaturesSetId=9, CharacteristicId=1, Value="black"},
                new FeaturesOfNomenclature {Id=16, FeaturesSetId=9, CharacteristicId=2, Value="41"},

                new FeaturesOfNomenclature {Id=17, FeaturesSetId=10, CharacteristicId=1, Value="brown"},
                new FeaturesOfNomenclature {Id=18, FeaturesSetId=10, CharacteristicId=2, Value="39"},

                new FeaturesOfNomenclature {Id=19, FeaturesSetId=11, CharacteristicId=1, Value="gray"},
                new FeaturesOfNomenclature {Id=20, FeaturesSetId=11, CharacteristicId=2, Value="38"},
                new FeaturesOfNomenclature {Id=21, FeaturesSetId=12, CharacteristicId=1, Value="gray"},
                new FeaturesOfNomenclature {Id=22, FeaturesSetId=12, CharacteristicId=2, Value="39"},
                new FeaturesOfNomenclature {Id=23, FeaturesSetId=13, CharacteristicId=1, Value="gray"},
                new FeaturesOfNomenclature {Id=24, FeaturesSetId=13, CharacteristicId=2, Value="41"},

                new FeaturesOfNomenclature {Id=25, FeaturesSetId=14, CharacteristicId=1, Value="blue-green"},
                new FeaturesOfNomenclature {Id=26, FeaturesSetId=14, CharacteristicId=2, Value="116/122"},
                new FeaturesOfNomenclature {Id=27, FeaturesSetId=15, CharacteristicId=1, Value="blue-green"},
                new FeaturesOfNomenclature {Id=28, FeaturesSetId=15, CharacteristicId=2, Value="128/134"},
                new FeaturesOfNomenclature {Id=29, FeaturesSetId=16, CharacteristicId=1, Value="blue-green"},
                new FeaturesOfNomenclature {Id=30, FeaturesSetId=16, CharacteristicId=2, Value="140/146"},
                new FeaturesOfNomenclature {Id=31, FeaturesSetId=17, CharacteristicId=1, Value="blue-green"},
                new FeaturesOfNomenclature {Id=32, FeaturesSetId=17, CharacteristicId=2, Value="152/158"},

                new FeaturesOfNomenclature {Id=33, FeaturesSetId=18, CharacteristicId=1, Value="blue-red"},
                new FeaturesOfNomenclature {Id=34, FeaturesSetId=18, CharacteristicId=2, Value="116/122"},
                new FeaturesOfNomenclature {Id=35, FeaturesSetId=19, CharacteristicId=1, Value="blue-red"},
                new FeaturesOfNomenclature {Id=36, FeaturesSetId=19, CharacteristicId=2, Value="128/134"},
                new FeaturesOfNomenclature {Id=37, FeaturesSetId=20, CharacteristicId=1, Value="blue-red"},
                new FeaturesOfNomenclature {Id=38, FeaturesSetId=20, CharacteristicId=2, Value="140/146"},
                new FeaturesOfNomenclature {Id=39, FeaturesSetId=21, CharacteristicId=1, Value="blue-red"},
                new FeaturesOfNomenclature {Id=40, FeaturesSetId=21, CharacteristicId=2, Value="164/170"},

                new FeaturesOfNomenclature {Id=41, FeaturesSetId=22, CharacteristicId=1, Value="green"},
                new FeaturesOfNomenclature {Id=42, FeaturesSetId=22, CharacteristicId=2, Value="128/134"},
                new FeaturesOfNomenclature {Id=43, FeaturesSetId=23, CharacteristicId=1, Value="green"},
                new FeaturesOfNomenclature {Id=44, FeaturesSetId=23, CharacteristicId=2, Value="140/146"},
                new FeaturesOfNomenclature {Id=45, FeaturesSetId=24, CharacteristicId=1, Value="green"},
                new FeaturesOfNomenclature {Id=46, FeaturesSetId=24, CharacteristicId=2, Value="152/158"},

                new FeaturesOfNomenclature {Id=47, FeaturesSetId=25, CharacteristicId=1, Value="blue-gray"},
                new FeaturesOfNomenclature {Id=48, FeaturesSetId=25, CharacteristicId=2, Value="128"},
                new FeaturesOfNomenclature {Id=49, FeaturesSetId=26, CharacteristicId=1, Value="blue-gray"},
                new FeaturesOfNomenclature {Id=50, FeaturesSetId=26, CharacteristicId=2, Value="134"},
                new FeaturesOfNomenclature {Id=51, FeaturesSetId=27, CharacteristicId=1, Value="blue-gray"},
                new FeaturesOfNomenclature {Id=52, FeaturesSetId=27, CharacteristicId=2, Value="140"},
                new FeaturesOfNomenclature {Id=53, FeaturesSetId=28, CharacteristicId=1, Value="blue-gray"},
                new FeaturesOfNomenclature {Id=54, FeaturesSetId=28, CharacteristicId=2, Value="146"},
                new FeaturesOfNomenclature {Id=55, FeaturesSetId=29, CharacteristicId=1, Value="blue-gray"},
                new FeaturesOfNomenclature {Id=56, FeaturesSetId=29, CharacteristicId=2, Value="152"},
                new FeaturesOfNomenclature {Id=57, FeaturesSetId=30, CharacteristicId=1, Value="blue-gray"},
                new FeaturesOfNomenclature {Id=58, FeaturesSetId=30, CharacteristicId=2, Value="158"},
                new FeaturesOfNomenclature {Id=59, FeaturesSetId=31, CharacteristicId=1, Value="blue-gray"},
                new FeaturesOfNomenclature {Id=60, FeaturesSetId=31, CharacteristicId=2, Value="164"},

                new FeaturesOfNomenclature {Id=61, FeaturesSetId=32, CharacteristicId=1, Value="orange-black"},
                new FeaturesOfNomenclature {Id=62, FeaturesSetId=32, CharacteristicId=2, Value="122"},
                new FeaturesOfNomenclature {Id=63, FeaturesSetId=33, CharacteristicId=1, Value="orange-black"},
                new FeaturesOfNomenclature {Id=64, FeaturesSetId=33, CharacteristicId=2, Value="128"},
                new FeaturesOfNomenclature {Id=65, FeaturesSetId=34, CharacteristicId=1, Value="orange-black"},
                new FeaturesOfNomenclature {Id=66, FeaturesSetId=34, CharacteristicId=2, Value="134"},
                new FeaturesOfNomenclature {Id=67, FeaturesSetId=35, CharacteristicId=1, Value="orange-black"},
                new FeaturesOfNomenclature {Id=68, FeaturesSetId=35, CharacteristicId=2, Value="140"},
                new FeaturesOfNomenclature {Id=69, FeaturesSetId=36, CharacteristicId=1, Value="orange-black"},
                new FeaturesOfNomenclature {Id=70, FeaturesSetId=36, CharacteristicId=2, Value="146"},
                new FeaturesOfNomenclature {Id=71, FeaturesSetId=37, CharacteristicId=1, Value="orange-black"},
                new FeaturesOfNomenclature {Id=72, FeaturesSetId=37, CharacteristicId=2, Value="152"},
                new FeaturesOfNomenclature {Id=73, FeaturesSetId=38, CharacteristicId=1, Value="orange-black"},
                new FeaturesOfNomenclature {Id=74, FeaturesSetId=38, CharacteristicId=2, Value="158"},
                new FeaturesOfNomenclature {Id=75, FeaturesSetId=39, CharacteristicId=1, Value="orange-black"},
                new FeaturesOfNomenclature {Id=76, FeaturesSetId=39, CharacteristicId=2, Value="164"},

                new FeaturesOfNomenclature {Id=77, FeaturesSetId=40, CharacteristicId=1, Value="green"},
                new FeaturesOfNomenclature {Id=78, FeaturesSetId=40, CharacteristicId=2, Value="128"},
                new FeaturesOfNomenclature {Id=79, FeaturesSetId=41, CharacteristicId=1, Value="green"},
                new FeaturesOfNomenclature {Id=80, FeaturesSetId=41, CharacteristicId=2, Value="134"},
                new FeaturesOfNomenclature {Id=81, FeaturesSetId=42, CharacteristicId=1, Value="green"},
                new FeaturesOfNomenclature {Id=82, FeaturesSetId=42, CharacteristicId=2, Value="140"},
                new FeaturesOfNomenclature {Id=83, FeaturesSetId=43, CharacteristicId=1, Value="green"},
                new FeaturesOfNomenclature {Id=84, FeaturesSetId=43, CharacteristicId=2, Value="146"},
                new FeaturesOfNomenclature {Id=85, FeaturesSetId=44, CharacteristicId=1, Value="green"},
                new FeaturesOfNomenclature {Id=86, FeaturesSetId=44, CharacteristicId=2, Value="152"},
                new FeaturesOfNomenclature {Id=87, FeaturesSetId=45, CharacteristicId=1, Value="green"},
                new FeaturesOfNomenclature {Id=88, FeaturesSetId=45, CharacteristicId=2, Value="158"},
                new FeaturesOfNomenclature {Id=89, FeaturesSetId=46, CharacteristicId=1, Value="green"},
                new FeaturesOfNomenclature {Id=90, FeaturesSetId=46, CharacteristicId=2, Value="164"},
                new FeaturesOfNomenclature {Id=91, FeaturesSetId=47, CharacteristicId=1, Value="green"},
                new FeaturesOfNomenclature {Id=92, FeaturesSetId=47, CharacteristicId=2, Value="170"},
                new FeaturesOfNomenclature {Id=93, FeaturesSetId=48, CharacteristicId=1, Value="green"},
                new FeaturesOfNomenclature {Id=94, FeaturesSetId=48, CharacteristicId=2, Value="176"},

                new FeaturesOfNomenclature {Id=77, FeaturesSetId=49, CharacteristicId=1, Value="violet"},
                new FeaturesOfNomenclature {Id=78, FeaturesSetId=49, CharacteristicId=2, Value="92"},
                new FeaturesOfNomenclature {Id=79, FeaturesSetId=50, CharacteristicId=1, Value="violet"},
                new FeaturesOfNomenclature {Id=80, FeaturesSetId=50, CharacteristicId=2, Value="98"},
                new FeaturesOfNomenclature {Id=81, FeaturesSetId=51, CharacteristicId=1, Value="violet"},
                new FeaturesOfNomenclature {Id=82, FeaturesSetId=51, CharacteristicId=2, Value="104"},
                new FeaturesOfNomenclature {Id=83, FeaturesSetId=52, CharacteristicId=1, Value="violet"},
                new FeaturesOfNomenclature {Id=84, FeaturesSetId=52, CharacteristicId=2, Value="110"},
                new FeaturesOfNomenclature {Id=85, FeaturesSetId=53, CharacteristicId=1, Value="violet"},
                new FeaturesOfNomenclature {Id=86, FeaturesSetId=53, CharacteristicId=2, Value="116"},
                new FeaturesOfNomenclature {Id=87, FeaturesSetId=54, CharacteristicId=1, Value="violet"},
                new FeaturesOfNomenclature {Id=88, FeaturesSetId=54, CharacteristicId=2, Value="122"},
                new FeaturesOfNomenclature {Id=89, FeaturesSetId=55, CharacteristicId=1, Value="violet"},
                new FeaturesOfNomenclature {Id=90, FeaturesSetId=55, CharacteristicId=2, Value="128"},
                new FeaturesOfNomenclature {Id=91, FeaturesSetId=56, CharacteristicId=1, Value="violet"},
                new FeaturesOfNomenclature {Id=92, FeaturesSetId=56, CharacteristicId=2, Value="134"},
                new FeaturesOfNomenclature {Id=93, FeaturesSetId=57, CharacteristicId=1, Value="violet"},
                new FeaturesOfNomenclature {Id=94, FeaturesSetId=57, CharacteristicId=2, Value="140"},
                new FeaturesOfNomenclature {Id=89, FeaturesSetId=58, CharacteristicId=1, Value="violet"},
                new FeaturesOfNomenclature {Id=90, FeaturesSetId=58, CharacteristicId=2, Value="146"},
                new FeaturesOfNomenclature {Id=91, FeaturesSetId=59, CharacteristicId=1, Value="violet"},
                new FeaturesOfNomenclature {Id=92, FeaturesSetId=59, CharacteristicId=2, Value="152"},
                new FeaturesOfNomenclature {Id=93, FeaturesSetId=60, CharacteristicId=1, Value="violet"},
                new FeaturesOfNomenclature {Id=94, FeaturesSetId=60, CharacteristicId=2, Value="158"},
                new FeaturesOfNomenclature {Id=91, FeaturesSetId=61, CharacteristicId=1, Value="violet"},
                new FeaturesOfNomenclature {Id=92, FeaturesSetId=61, CharacteristicId=2, Value="164"},

                new FeaturesOfNomenclature {Id=93, FeaturesSetId=62, CharacteristicId=1, Value="blue"},
                new FeaturesOfNomenclature {Id=94, FeaturesSetId=62, CharacteristicId=2, Value="92"},
                new FeaturesOfNomenclature {Id=95, FeaturesSetId=63, CharacteristicId=1, Value="blue"},
                new FeaturesOfNomenclature {Id=96, FeaturesSetId=63, CharacteristicId=2, Value="98"},
                new FeaturesOfNomenclature {Id=97, FeaturesSetId=64, CharacteristicId=1, Value="blue"},
                new FeaturesOfNomenclature {Id=98, FeaturesSetId=64, CharacteristicId=2, Value="104"},
                new FeaturesOfNomenclature {Id=99, FeaturesSetId=65, CharacteristicId=1, Value="blue"},
                new FeaturesOfNomenclature {Id=100, FeaturesSetId=65, CharacteristicId=2, Value="110"},
                new FeaturesOfNomenclature {Id=101, FeaturesSetId=66, CharacteristicId=1, Value="blue"},
                new FeaturesOfNomenclature {Id=102, FeaturesSetId=66, CharacteristicId=2, Value="116"},
                new FeaturesOfNomenclature {Id=103, FeaturesSetId=67, CharacteristicId=1, Value="blue"},
                new FeaturesOfNomenclature {Id=104, FeaturesSetId=67, CharacteristicId=2, Value="122"},
                new FeaturesOfNomenclature {Id=105, FeaturesSetId=68, CharacteristicId=1, Value="blue"},
                new FeaturesOfNomenclature {Id=106, FeaturesSetId=68, CharacteristicId=2, Value="128"},
                new FeaturesOfNomenclature {Id=107, FeaturesSetId=69, CharacteristicId=1, Value="blue"},
                new FeaturesOfNomenclature {Id=108, FeaturesSetId=69, CharacteristicId=2, Value="134"},
                new FeaturesOfNomenclature {Id=109, FeaturesSetId=70, CharacteristicId=1, Value="blue"},
                new FeaturesOfNomenclature {Id=110, FeaturesSetId=70, CharacteristicId=2, Value="140"},
                new FeaturesOfNomenclature {Id=111, FeaturesSetId=71, CharacteristicId=1, Value="blue"},
                new FeaturesOfNomenclature {Id=112, FeaturesSetId=71, CharacteristicId=2, Value="146"},
                new FeaturesOfNomenclature {Id=113, FeaturesSetId=72, CharacteristicId=1, Value="blue"},
                new FeaturesOfNomenclature {Id=114, FeaturesSetId=72, CharacteristicId=2, Value="152"},
                new FeaturesOfNomenclature {Id=115, FeaturesSetId=73, CharacteristicId=1, Value="blue"},
                new FeaturesOfNomenclature {Id=116, FeaturesSetId=73, CharacteristicId=2, Value="158"},
                new FeaturesOfNomenclature {Id=117, FeaturesSetId=74, CharacteristicId=1, Value="blue"},
                new FeaturesOfNomenclature {Id=118, FeaturesSetId=74, CharacteristicId=2, Value="164"},

                new FeaturesOfNomenclature {Id=119, FeaturesSetId=75, CharacteristicId=1, Value="red"},
                new FeaturesOfNomenclature {Id=120, FeaturesSetId=75, CharacteristicId=2, Value="92"},
                new FeaturesOfNomenclature {Id=121, FeaturesSetId=76, CharacteristicId=1, Value="red"},
                new FeaturesOfNomenclature {Id=122, FeaturesSetId=76, CharacteristicId=2, Value="98"},
                new FeaturesOfNomenclature {Id=123, FeaturesSetId=77, CharacteristicId=1, Value="red"},
                new FeaturesOfNomenclature {Id=124, FeaturesSetId=77, CharacteristicId=2, Value="104"},
                new FeaturesOfNomenclature {Id=125, FeaturesSetId=78, CharacteristicId=1, Value="red"},
                new FeaturesOfNomenclature {Id=126, FeaturesSetId=78, CharacteristicId=2, Value="110"},
                new FeaturesOfNomenclature {Id=127, FeaturesSetId=79, CharacteristicId=1, Value="red"},
                new FeaturesOfNomenclature {Id=128, FeaturesSetId=79, CharacteristicId=2, Value="116"},
                new FeaturesOfNomenclature {Id=129, FeaturesSetId=80, CharacteristicId=1, Value="red"},
                new FeaturesOfNomenclature {Id=130, FeaturesSetId=80, CharacteristicId=2, Value="122"},
                new FeaturesOfNomenclature {Id=131, FeaturesSetId=81, CharacteristicId=1, Value="red"},
                new FeaturesOfNomenclature {Id=132, FeaturesSetId=81, CharacteristicId=2, Value="128"},
                new FeaturesOfNomenclature {Id=133, FeaturesSetId=82, CharacteristicId=1, Value="red"},
                new FeaturesOfNomenclature {Id=134, FeaturesSetId=82, CharacteristicId=2, Value="134"},
                new FeaturesOfNomenclature {Id=135, FeaturesSetId=83, CharacteristicId=1, Value="red"},
                new FeaturesOfNomenclature {Id=136, FeaturesSetId=83, CharacteristicId=2, Value="140"},
                new FeaturesOfNomenclature {Id=137, FeaturesSetId=84, CharacteristicId=1, Value="red"},
                new FeaturesOfNomenclature {Id=138, FeaturesSetId=84, CharacteristicId=2, Value="146"},
                new FeaturesOfNomenclature {Id=139, FeaturesSetId=85, CharacteristicId=1, Value="red"},
                new FeaturesOfNomenclature {Id=140, FeaturesSetId=85, CharacteristicId=2, Value="152"},
                new FeaturesOfNomenclature {Id=141, FeaturesSetId=86, CharacteristicId=1, Value="red"},
                new FeaturesOfNomenclature {Id=142, FeaturesSetId=86, CharacteristicId=2, Value="158"},
                new FeaturesOfNomenclature {Id=143, FeaturesSetId=87, CharacteristicId=1, Value="red"},
                new FeaturesOfNomenclature {Id=144, FeaturesSetId=87, CharacteristicId=2, Value="164"},

                new FeaturesOfNomenclature {Id=145, FeaturesSetId=88, CharacteristicId=1, Value="gray"},
                new FeaturesOfNomenclature {Id=146, FeaturesSetId=88, CharacteristicId=2, Value="92"},
                new FeaturesOfNomenclature {Id=147, FeaturesSetId=89, CharacteristicId=1, Value="gray"},
                new FeaturesOfNomenclature {Id=148, FeaturesSetId=89, CharacteristicId=2, Value="98"},
                new FeaturesOfNomenclature {Id=149, FeaturesSetId=90, CharacteristicId=1, Value="gray"},
                new FeaturesOfNomenclature {Id=150, FeaturesSetId=90, CharacteristicId=2, Value="104"},
                new FeaturesOfNomenclature {Id=151, FeaturesSetId=91, CharacteristicId=1, Value="gray"},
                new FeaturesOfNomenclature {Id=152, FeaturesSetId=91, CharacteristicId=2, Value="110"},
                new FeaturesOfNomenclature {Id=153, FeaturesSetId=92, CharacteristicId=1, Value="gray"},
                new FeaturesOfNomenclature {Id=154, FeaturesSetId=92, CharacteristicId=2, Value="116"},
                new FeaturesOfNomenclature {Id=155, FeaturesSetId=93, CharacteristicId=1, Value="gray"},
                new FeaturesOfNomenclature {Id=156, FeaturesSetId=93, CharacteristicId=2, Value="122"},
                new FeaturesOfNomenclature {Id=157, FeaturesSetId=94, CharacteristicId=1, Value="gray"},
                new FeaturesOfNomenclature {Id=158, FeaturesSetId=94, CharacteristicId=2, Value="128"},
                new FeaturesOfNomenclature {Id=159, FeaturesSetId=95, CharacteristicId=1, Value="gray"},
                new FeaturesOfNomenclature {Id=160, FeaturesSetId=95, CharacteristicId=2, Value="134"},
                new FeaturesOfNomenclature {Id=161, FeaturesSetId=96, CharacteristicId=1, Value="gray"},
                new FeaturesOfNomenclature {Id=162, FeaturesSetId=96, CharacteristicId=2, Value="140"},
                new FeaturesOfNomenclature {Id=163, FeaturesSetId=97, CharacteristicId=1, Value="gray"},
                new FeaturesOfNomenclature {Id=164, FeaturesSetId=97, CharacteristicId=2, Value="146"},
                new FeaturesOfNomenclature {Id=165, FeaturesSetId=98, CharacteristicId=1, Value="gray"},
                new FeaturesOfNomenclature {Id=166, FeaturesSetId=98, CharacteristicId=2, Value="152"},
                new FeaturesOfNomenclature {Id=167, FeaturesSetId=99, CharacteristicId=1, Value="gray"},
                new FeaturesOfNomenclature {Id=168, FeaturesSetId=99, CharacteristicId=2, Value="158"},
                new FeaturesOfNomenclature {Id=169, FeaturesSetId=100, CharacteristicId=1, Value="gray"},
                new FeaturesOfNomenclature {Id=170, FeaturesSetId=100, CharacteristicId=2, Value="164"},

            };
            featuresofnumenclatures.ForEach(x => context.FeaturesOfNomenclatures.Add(x));
            context.SaveChanges();


            List<NomenclatureView> nomenclatureviews = new List<NomenclatureView>()
            {
                new NomenclatureView {Id=1, NomenclatureId=1, FeaturesSetId=1, Image="boots1_brown"},
                new NomenclatureView {Id=2, NomenclatureId=1, FeaturesSetId=2, Image="boots1_brown"},
                new NomenclatureView {Id=3, NomenclatureId=1, FeaturesSetId=3, Image="boots1_yellow"},
                new NomenclatureView {Id=4, NomenclatureId=1, FeaturesSetId=4, Image="boots1_yellow"},
                
                new NomenclatureView {Id=5, NomenclatureId=2, FeaturesSetId=5, Image="boots2_white"},
                new NomenclatureView {Id=6, NomenclatureId=2, FeaturesSetId=6, Image="boots2_black"},
                
                new NomenclatureView {Id=7, NomenclatureId=3, FeaturesSetId=7, Image="boots3_red"},
                new NomenclatureView {Id=8, NomenclatureId=3, FeaturesSetId=8, Image="boots3_gray"},
                new NomenclatureView {Id=9, NomenclatureId=3, FeaturesSetId=6, Image="boots3_black"},
                new NomenclatureView {Id=10, NomenclatureId=3, FeaturesSetId=9, Image="boots3_black"},
                
                new NomenclatureView {Id=11, NomenclatureId=4, FeaturesSetId=6, Image="boots4_black"},
                new NomenclatureView {Id=12, NomenclatureId=4, FeaturesSetId=9, Image="boots4_black"},
                
                new NomenclatureView {Id=13, NomenclatureId=5, FeaturesSetId=1, Image="boots5_brown"},
                new NomenclatureView {Id=14, NomenclatureId=5, FeaturesSetId=2, Image="boots5_brown"},
                new NomenclatureView {Id=15, NomenclatureId=5, FeaturesSetId=10, Image="boots5_brown"},
                
                new NomenclatureView {Id=16, NomenclatureId=6, FeaturesSetId=8, Image="boots6_gray"},
                new NomenclatureView {Id=17, NomenclatureId=6, FeaturesSetId=11, Image="boots6_gray"},
                new NomenclatureView {Id=18, NomenclatureId=6, FeaturesSetId=12, Image="boots6_gray"},
                new NomenclatureView {Id=19, NomenclatureId=6, FeaturesSetId=13, Image="boots6_gray"},

                new NomenclatureView {Id=20, NomenclatureId=7, FeaturesSetId=14, Image="coat1_blue-green"},
                new NomenclatureView {Id=21, NomenclatureId=7, FeaturesSetId=15, Image="coat1_blue-green"},
                new NomenclatureView {Id=22, NomenclatureId=7, FeaturesSetId=16, Image="coat1_blue-green"},
                new NomenclatureView {Id=23, NomenclatureId=7, FeaturesSetId=17, Image="coat1_blue-green"},
                new NomenclatureView {Id=24, NomenclatureId=7, FeaturesSetId=18, Image="coat1_blue-red"},
                new NomenclatureView {Id=25, NomenclatureId=7, FeaturesSetId=19, Image="coat1_blue-red"},
                new NomenclatureView {Id=26, NomenclatureId=7, FeaturesSetId=20, Image="coat1_blue-red"},
                new NomenclatureView {Id=27, NomenclatureId=7, FeaturesSetId=21, Image="coat1_blue-red"},
                
                new NomenclatureView {Id=28, NomenclatureId=8, FeaturesSetId=22, Image="coat2_green"},
                new NomenclatureView {Id=29, NomenclatureId=8, FeaturesSetId=23, Image="coat2_green"},
                new NomenclatureView {Id=30, NomenclatureId=8, FeaturesSetId=24, Image="coat2_green"},

                new NomenclatureView {Id=31, NomenclatureId=9, FeaturesSetId=25, Image="coat3_blue-gray"},
                new NomenclatureView {Id=32, NomenclatureId=9, FeaturesSetId=26, Image="coat3_blue-gray"},
                new NomenclatureView {Id=33, NomenclatureId=9, FeaturesSetId=27, Image="coat3_blue-gray"},
                new NomenclatureView {Id=34, NomenclatureId=9, FeaturesSetId=28, Image="coat3_blue-gray"},
                new NomenclatureView {Id=35, NomenclatureId=9, FeaturesSetId=29, Image="coat3_blue-gray"},
                new NomenclatureView {Id=36, NomenclatureId=9, FeaturesSetId=30, Image="coat3_blue-gray"},
                new NomenclatureView {Id=37, NomenclatureId=9, FeaturesSetId=31, Image="coat3_blue-gray"},

                new NomenclatureView {Id=38, NomenclatureId=10, FeaturesSetId=32, Image="coat4_orange-black"},
                new NomenclatureView {Id=39, NomenclatureId=10, FeaturesSetId=33, Image="coat4_orange-black"},
                new NomenclatureView {Id=40, NomenclatureId=10, FeaturesSetId=34, Image="coat4_orange-black"},
                new NomenclatureView {Id=41, NomenclatureId=10, FeaturesSetId=35, Image="coat4_orange-black"},
                new NomenclatureView {Id=42, NomenclatureId=10, FeaturesSetId=36, Image="coat4_orange-black"},
                new NomenclatureView {Id=43, NomenclatureId=10, FeaturesSetId=37, Image="coat4_orange-black"},
                new NomenclatureView {Id=44, NomenclatureId=10, FeaturesSetId=38, Image="coat4_orange-black"},
                new NomenclatureView {Id=45, NomenclatureId=10, FeaturesSetId=39, Image="coat4_orange-black"},

                new NomenclatureView {Id=46, NomenclatureId=11, FeaturesSetId=40, Image="coat5_green"},
                new NomenclatureView {Id=47, NomenclatureId=11, FeaturesSetId=41, Image="coat5_green"},
                new NomenclatureView {Id=48, NomenclatureId=11, FeaturesSetId=42, Image="coat5_green"},
                new NomenclatureView {Id=49, NomenclatureId=11, FeaturesSetId=43, Image="coat5_green"},
                new NomenclatureView {Id=50, NomenclatureId=11, FeaturesSetId=44, Image="coat5_green"},
                new NomenclatureView {Id=51, NomenclatureId=11, FeaturesSetId=45, Image="coat5_green"},
                new NomenclatureView {Id=52, NomenclatureId=11, FeaturesSetId=46, Image="coat5_green"},
                new NomenclatureView {Id=53, NomenclatureId=11, FeaturesSetId=47, Image="coat5_green"},
                new NomenclatureView {Id=54, NomenclatureId=11, FeaturesSetId=48, Image="coat5_green"},

                new NomenclatureView {Id=55, NomenclatureId=12, FeaturesSetId=49, Image="wintertrousers1_violet"},
                new NomenclatureView {Id=56, NomenclatureId=12, FeaturesSetId=50, Image="wintertrousers1_violet"},
                new NomenclatureView {Id=57, NomenclatureId=12, FeaturesSetId=51, Image="wintertrousers1_violet"},
                new NomenclatureView {Id=58, NomenclatureId=12, FeaturesSetId=52, Image="wintertrousers1_violet"},
                new NomenclatureView {Id=59, NomenclatureId=12, FeaturesSetId=53, Image="wintertrousers1_violet"},
                new NomenclatureView {Id=60, NomenclatureId=12, FeaturesSetId=54, Image="wintertrousers1_violet"},
                new NomenclatureView {Id=61, NomenclatureId=12, FeaturesSetId=55, Image="wintertrousers1_violet"},
                new NomenclatureView {Id=62, NomenclatureId=12, FeaturesSetId=56, Image="wintertrousers1_violet"},
                new NomenclatureView {Id=63, NomenclatureId=12, FeaturesSetId=57, Image="wintertrousers1_violet"},
                new NomenclatureView {Id=59, NomenclatureId=12, FeaturesSetId=58, Image="wintertrousers1_violet"},
                new NomenclatureView {Id=60, NomenclatureId=12, FeaturesSetId=59, Image="wintertrousers1_violet"},
                new NomenclatureView {Id=61, NomenclatureId=12, FeaturesSetId=60, Image="wintertrousers1_violet"},
                new NomenclatureView {Id=62, NomenclatureId=12, FeaturesSetId=61, Image="wintertrousers1_violet"},

                new NomenclatureView {Id=55, NomenclatureId=12, FeaturesSetId=62, Image="wintertrousers1_blue"},
                new NomenclatureView {Id=56, NomenclatureId=12, FeaturesSetId=63, Image="wintertrousers1_blue"},
                new NomenclatureView {Id=57, NomenclatureId=12, FeaturesSetId=64, Image="wintertrousers1_blue"},
                new NomenclatureView {Id=58, NomenclatureId=12, FeaturesSetId=65, Image="wintertrousers1_blue"},
                new NomenclatureView {Id=59, NomenclatureId=12, FeaturesSetId=66, Image="wintertrousers1_blue"},
                new NomenclatureView {Id=60, NomenclatureId=12, FeaturesSetId=67, Image="wintertrousers1_blue"},
                new NomenclatureView {Id=61, NomenclatureId=12, FeaturesSetId=68, Image="wintertrousers1_blue"},
                new NomenclatureView {Id=62, NomenclatureId=12, FeaturesSetId=69, Image="wintertrousers1_blue"},
                new NomenclatureView {Id=63, NomenclatureId=12, FeaturesSetId=70, Image="wintertrousers1_blue"},
                new NomenclatureView {Id=59, NomenclatureId=12, FeaturesSetId=71, Image="wintertrousers1_blue"},
                new NomenclatureView {Id=60, NomenclatureId=12, FeaturesSetId=72, Image="wintertrousers1_blue"},
                new NomenclatureView {Id=61, NomenclatureId=12, FeaturesSetId=73, Image="wintertrousers1_blue"},
                new NomenclatureView {Id=62, NomenclatureId=12, FeaturesSetId=74, Image="wintertrousers1_blue"},

                new NomenclatureView {Id=63, NomenclatureId=12, FeaturesSetId=75, Image="wintertrousers1_red"},
                new NomenclatureView {Id=64, NomenclatureId=12, FeaturesSetId=76, Image="wintertrousers1_red"},
                new NomenclatureView {Id=65, NomenclatureId=12, FeaturesSetId=77, Image="wintertrousers1_red"},
                new NomenclatureView {Id=66, NomenclatureId=12, FeaturesSetId=78, Image="wintertrousers1_red"},
                new NomenclatureView {Id=67, NomenclatureId=12, FeaturesSetId=79, Image="wintertrousers1_red"},
                new NomenclatureView {Id=68, NomenclatureId=12, FeaturesSetId=80, Image="wintertrousers1_red"},
                new NomenclatureView {Id=69, NomenclatureId=12, FeaturesSetId=81, Image="wintertrousers1_red"},
                new NomenclatureView {Id=70, NomenclatureId=12, FeaturesSetId=82, Image="wintertrousers1_red"},
                new NomenclatureView {Id=71, NomenclatureId=12, FeaturesSetId=83, Image="wintertrousers1_red"},
                new NomenclatureView {Id=72, NomenclatureId=12, FeaturesSetId=84, Image="wintertrousers1_red"},
                new NomenclatureView {Id=73, NomenclatureId=12, FeaturesSetId=85, Image="wintertrousers1_red"},
                new NomenclatureView {Id=74, NomenclatureId=12, FeaturesSetId=86, Image="wintertrousers1_red"},
                new NomenclatureView {Id=75, NomenclatureId=12, FeaturesSetId=87, Image="wintertrousers1_red"},

                new NomenclatureView {Id=63, NomenclatureId=12, FeaturesSetId=88, Image="wintertrousers1_gray"},
                new NomenclatureView {Id=64, NomenclatureId=12, FeaturesSetId=89, Image="wintertrousers1_gray"},
                new NomenclatureView {Id=65, NomenclatureId=12, FeaturesSetId=90, Image="wintertrousers1_gray"},
                new NomenclatureView {Id=66, NomenclatureId=12, FeaturesSetId=91, Image="wintertrousers1_gray"},
                new NomenclatureView {Id=67, NomenclatureId=12, FeaturesSetId=92, Image="wintertrousers1_gray"},
                new NomenclatureView {Id=68, NomenclatureId=12, FeaturesSetId=93, Image="wintertrousers1_gray"},
                new NomenclatureView {Id=69, NomenclatureId=12, FeaturesSetId=94, Image="wintertrousers1_gray"},
                new NomenclatureView {Id=70, NomenclatureId=12, FeaturesSetId=95, Image="wintertrousers1_gray"},
                new NomenclatureView {Id=71, NomenclatureId=12, FeaturesSetId=96, Image="wintertrousers1_gray"},
                new NomenclatureView {Id=72, NomenclatureId=12, FeaturesSetId=97, Image="wintertrousers1_gray"},
                new NomenclatureView {Id=73, NomenclatureId=12, FeaturesSetId=98, Image="wintertrousers1_gray"},
                new NomenclatureView {Id=74, NomenclatureId=12, FeaturesSetId=99, Image="wintertrousers1_gray"},
                new NomenclatureView {Id=75, NomenclatureId=12, FeaturesSetId=100, Image="wintertrousers1_gray"},

            };

            nomenclatureviews.ForEach(x => context.NomenclatureViews.Add(x));
            context.SaveChanges();

            List<Store> stores = new List<Store>() 
            {
                new Store {Id=1, Name="Main"},
                new Store {Id=2, Name="Sub1"},
                new Store {Id=3, Name="Sub2"}
            };
            stores.ForEach(x => context.Stores.Add(x));
            context.SaveChanges();

            List<NomenclatureInStore> nomenclatureinstores = new List<NomenclatureInStore>() 
            {
                new NomenclatureInStore {Id=1, StoreId=1, NomenclatureId=1, FeaturesSet=1, Amount=7},
                new NomenclatureInStore {Id=2, StoreId=1, NomenclatureId=1, FeaturesSet=2, Amount=5},
                //new NomenclatureInStore {Id=3, StoreId=1, NomenclatureId=1, FeaturesSet=3, Amount=10},
                //new NomenclatureInStore {Id=4, StoreId=1, NomenclatureId=1, FeaturesSet=4, Amount=2},

                new NomenclatureInStore {Id=5, StoreId=2, NomenclatureId=1, FeaturesSet=1, Amount=2},
                new NomenclatureInStore {Id=6, StoreId=2, NomenclatureId=1, FeaturesSet=2, Amount=0},
                //new NomenclatureInStore {Id=7, StoreId=2, NomenclatureId=1, FeaturesSet=3, Amount=11},
                //new NomenclatureInStore {Id=8, StoreId=2, NomenclatureId=1, FeaturesSet=4, Amount=8},

                new NomenclatureInStore {Id=9, StoreId=1, NomenclatureId=2, FeaturesSet=5, Amount=4},
                new NomenclatureInStore {Id=10, StoreId=1, NomenclatureId=2, FeaturesSet=6, Amount=8},
                //new NomenclatureInStore {Id=11, StoreId=1, NomenclatureId=2, FeaturesSet=3, Amount=0},
                //new NomenclatureInStore {Id=12, StoreId=1, NomenclatureId=2, FeaturesSet=4, Amount=3},

                //new NomenclatureInStore {Id=13, StoreId=3, NomenclatureId=2, FeaturesSet=1, Amount=12},
                //new NomenclatureInStore {Id=14, StoreId=3, NomenclatureId=2, FeaturesSet=2, Amount=6},
                //new NomenclatureInStore {Id=15, StoreId=3, NomenclatureId=2, FeaturesSet=3, Amount=0},
                //new NomenclatureInStore {Id=16, StoreId=3, NomenclatureId=2, FeaturesSet=4, Amount=3},

                new NomenclatureInStore {Id=13, StoreId=1, NomenclatureId=3, FeaturesSet=7, Amount=12},
                new NomenclatureInStore {Id=14, StoreId=1, NomenclatureId=3, FeaturesSet=8, Amount=6},
                new NomenclatureInStore {Id=15, StoreId=1, NomenclatureId=3, FeaturesSet=6, Amount=4},
                new NomenclatureInStore {Id=16, StoreId=2, NomenclatureId=3, FeaturesSet=6, Amount=3},
                new NomenclatureInStore {Id=17, StoreId=3, NomenclatureId=3, FeaturesSet=9, Amount=5},

                new NomenclatureInStore {Id=18, StoreId=2, NomenclatureId=4, FeaturesSet=6, Amount=2},
                new NomenclatureInStore {Id=19, StoreId=2, NomenclatureId=4, FeaturesSet=9, Amount=7},
                //new NomenclatureInStore {Id=7, StoreId=2, NomenclatureId=1, FeaturesSet=3, Amount=11},
                //new NomenclatureInStore {Id=8, StoreId=2, NomenclatureId=1, FeaturesSet=4, Amount=8},

                new NomenclatureInStore {Id=20, StoreId=2, NomenclatureId=5, FeaturesSet=1, Amount=3},
                new NomenclatureInStore {Id=21, StoreId=2, NomenclatureId=5, FeaturesSet=2, Amount=5},
                new NomenclatureInStore {Id=22, StoreId=2, NomenclatureId=5, FeaturesSet=10, Amount=11},
                //new NomenclatureInStore {Id=8, StoreId=2, NomenclatureId=1, FeaturesSet=4, Amount=8},

                new NomenclatureInStore {Id=23, StoreId=2, NomenclatureId=6, FeaturesSet=8, Amount=2},
                new NomenclatureInStore {Id=24, StoreId=2, NomenclatureId=6, FeaturesSet=11, Amount=1},
                new NomenclatureInStore {Id=25, StoreId=2, NomenclatureId=6, FeaturesSet=12, Amount=9},
                new NomenclatureInStore {Id=26, StoreId=2, NomenclatureId=6, FeaturesSet=13, Amount=3},            

                new NomenclatureInStore {Id=23, StoreId=2, NomenclatureId=7, FeaturesSet=14, Amount=5},
                new NomenclatureInStore {Id=24, StoreId=2, NomenclatureId=7, FeaturesSet=15, Amount=2},
                new NomenclatureInStore {Id=25, StoreId=2, NomenclatureId=7, FeaturesSet=16, Amount=10},
                new NomenclatureInStore {Id=26, StoreId=2, NomenclatureId=7, FeaturesSet=17, Amount=5},            

                new NomenclatureInStore {Id=23, StoreId=2, NomenclatureId=7, FeaturesSet=18, Amount=1},
                new NomenclatureInStore {Id=24, StoreId=2, NomenclatureId=7, FeaturesSet=19, Amount=5},
                new NomenclatureInStore {Id=25, StoreId=2, NomenclatureId=7, FeaturesSet=20, Amount=12},
                new NomenclatureInStore {Id=26, StoreId=2, NomenclatureId=7, FeaturesSet=21, Amount=8},            
            
                new NomenclatureInStore {Id=27, StoreId=2, NomenclatureId=8, FeaturesSet=22, Amount=7},
                new NomenclatureInStore {Id=28, StoreId=2, NomenclatureId=8, FeaturesSet=23, Amount=3},
                new NomenclatureInStore {Id=29, StoreId=3, NomenclatureId=8, FeaturesSet=24, Amount=9},

                new NomenclatureInStore {Id=30, StoreId=1, NomenclatureId=9, FeaturesSet=25, Amount=2},
                new NomenclatureInStore {Id=31, StoreId=2, NomenclatureId=9, FeaturesSet=26, Amount=1},
                new NomenclatureInStore {Id=32, StoreId=1, NomenclatureId=9, FeaturesSet=27, Amount=6},
                new NomenclatureInStore {Id=33, StoreId=1, NomenclatureId=9, FeaturesSet=28, Amount=12},
                new NomenclatureInStore {Id=34, StoreId=3, NomenclatureId=9, FeaturesSet=29, Amount=7},
                new NomenclatureInStore {Id=35, StoreId=3, NomenclatureId=9, FeaturesSet=30, Amount=4},
                new NomenclatureInStore {Id=36, StoreId=3, NomenclatureId=9, FeaturesSet=31, Amount=2},

                new NomenclatureInStore {Id=37, StoreId=1, NomenclatureId=10, FeaturesSet=32, Amount=5},
                new NomenclatureInStore {Id=38, StoreId=1, NomenclatureId=10, FeaturesSet=33, Amount=2},
                new NomenclatureInStore {Id=39, StoreId=3, NomenclatureId=10, FeaturesSet=34, Amount=7},
                new NomenclatureInStore {Id=40, StoreId=2, NomenclatureId=10, FeaturesSet=35, Amount=14},
                new NomenclatureInStore {Id=41, StoreId=2, NomenclatureId=10, FeaturesSet=36, Amount=9},
                new NomenclatureInStore {Id=42, StoreId=1, NomenclatureId=10, FeaturesSet=37, Amount=5},
                new NomenclatureInStore {Id=43, StoreId=3, NomenclatureId=10, FeaturesSet=38, Amount=3},
                new NomenclatureInStore {Id=44, StoreId=3, NomenclatureId=10, FeaturesSet=39, Amount=1},

                new NomenclatureInStore {Id=45, StoreId=1, NomenclatureId=11, FeaturesSet=40, Amount=8},
                new NomenclatureInStore {Id=46, StoreId=2, NomenclatureId=11, FeaturesSet=41, Amount=9},
                new NomenclatureInStore {Id=47, StoreId=1, NomenclatureId=11, FeaturesSet=42, Amount=2},
                new NomenclatureInStore {Id=48, StoreId=1, NomenclatureId=11, FeaturesSet=43, Amount=1},
                new NomenclatureInStore {Id=49, StoreId=1, NomenclatureId=11, FeaturesSet=44, Amount=10},
                new NomenclatureInStore {Id=50, StoreId=3, NomenclatureId=11, FeaturesSet=45, Amount=7},
                new NomenclatureInStore {Id=51, StoreId=3, NomenclatureId=11, FeaturesSet=46, Amount=4},
                new NomenclatureInStore {Id=51, StoreId=2, NomenclatureId=11, FeaturesSet=47, Amount=5},
                new NomenclatureInStore {Id=53, StoreId=2, NomenclatureId=11, FeaturesSet=48, Amount=2},

                new NomenclatureInStore {Id=54, StoreId=2, NomenclatureId=12, FeaturesSet=49, Amount=5},
                new NomenclatureInStore {Id=55, StoreId=3, NomenclatureId=12, FeaturesSet=50, Amount=8},
                new NomenclatureInStore {Id=56, StoreId=3, NomenclatureId=12, FeaturesSet=51, Amount=3},
                new NomenclatureInStore {Id=57, StoreId=3, NomenclatureId=12, FeaturesSet=52, Amount=1},
                new NomenclatureInStore {Id=58, StoreId=1, NomenclatureId=12, FeaturesSet=53, Amount=1},
                new NomenclatureInStore {Id=59, StoreId=1, NomenclatureId=12, FeaturesSet=54, Amount=2},
                new NomenclatureInStore {Id=60, StoreId=2, NomenclatureId=12, FeaturesSet=55, Amount=5},
                new NomenclatureInStore {Id=61, StoreId=1, NomenclatureId=12, FeaturesSet=56, Amount=5},
                new NomenclatureInStore {Id=62, StoreId=3, NomenclatureId=12, FeaturesSet=57, Amount=1},
                new NomenclatureInStore {Id=63, StoreId=3, NomenclatureId=12, FeaturesSet=58, Amount=2},
                new NomenclatureInStore {Id=64, StoreId=1, NomenclatureId=12, FeaturesSet=59, Amount=7},
                new NomenclatureInStore {Id=65, StoreId=1, NomenclatureId=12, FeaturesSet=60, Amount=7},
                new NomenclatureInStore {Id=66, StoreId=3, NomenclatureId=12, FeaturesSet=61, Amount=9},

                new NomenclatureInStore {Id=67, StoreId=1, NomenclatureId=12, FeaturesSet=62, Amount=3},
                new NomenclatureInStore {Id=68, StoreId=1, NomenclatureId=12, FeaturesSet=63, Amount=1},
                new NomenclatureInStore {Id=69, StoreId=1, NomenclatureId=12, FeaturesSet=64, Amount=2},
                new NomenclatureInStore {Id=70, StoreId=2, NomenclatureId=12, FeaturesSet=65, Amount=2},
                new NomenclatureInStore {Id=71, StoreId=3, NomenclatureId=12, FeaturesSet=66, Amount=2},
                new NomenclatureInStore {Id=72, StoreId=3, NomenclatureId=12, FeaturesSet=67, Amount=1},
                new NomenclatureInStore {Id=73, StoreId=1, NomenclatureId=12, FeaturesSet=68, Amount=6},
                new NomenclatureInStore {Id=74, StoreId=3, NomenclatureId=12, FeaturesSet=69, Amount=7},
                new NomenclatureInStore {Id=75, StoreId=2, NomenclatureId=12, FeaturesSet=70, Amount=2},
                new NomenclatureInStore {Id=76, StoreId=3, NomenclatureId=12, FeaturesSet=71, Amount=4},
                new NomenclatureInStore {Id=77, StoreId=2, NomenclatureId=12, FeaturesSet=72, Amount=3},
                new NomenclatureInStore {Id=78, StoreId=2, NomenclatureId=12, FeaturesSet=73, Amount=2},
                new NomenclatureInStore {Id=79, StoreId=1, NomenclatureId=12, FeaturesSet=74, Amount=4},

                new NomenclatureInStore {Id=80, StoreId=2, NomenclatureId=12, FeaturesSet=75, Amount=4},
                new NomenclatureInStore {Id=81, StoreId=2, NomenclatureId=12, FeaturesSet=76, Amount=6},
                new NomenclatureInStore {Id=82, StoreId=3, NomenclatureId=12, FeaturesSet=77, Amount=1},
                new NomenclatureInStore {Id=83, StoreId=1, NomenclatureId=12, FeaturesSet=78, Amount=3},
                new NomenclatureInStore {Id=84, StoreId=2, NomenclatureId=12, FeaturesSet=79, Amount=4},
                new NomenclatureInStore {Id=85, StoreId=3, NomenclatureId=12, FeaturesSet=80, Amount=5},
                new NomenclatureInStore {Id=86, StoreId=2, NomenclatureId=12, FeaturesSet=81, Amount=2},
                new NomenclatureInStore {Id=87, StoreId=1, NomenclatureId=12, FeaturesSet=82, Amount=10},
                new NomenclatureInStore {Id=88, StoreId=1, NomenclatureId=12, FeaturesSet=83, Amount=3},
                new NomenclatureInStore {Id=89, StoreId=2, NomenclatureId=12, FeaturesSet=84, Amount=5},
                new NomenclatureInStore {Id=90, StoreId=3, NomenclatureId=12, FeaturesSet=85, Amount=1},
                new NomenclatureInStore {Id=91, StoreId=1, NomenclatureId=12, FeaturesSet=86, Amount=4},
                new NomenclatureInStore {Id=92, StoreId=3, NomenclatureId=12, FeaturesSet=87, Amount=1},

                new NomenclatureInStore {Id=93, StoreId=1, NomenclatureId=12, FeaturesSet=88, Amount=2},
                new NomenclatureInStore {Id=94, StoreId=3, NomenclatureId=12, FeaturesSet=89, Amount=1},
                new NomenclatureInStore {Id=95, StoreId=3, NomenclatureId=12, FeaturesSet=90, Amount=5},
                new NomenclatureInStore {Id=96, StoreId=1, NomenclatureId=12, FeaturesSet=91, Amount=7},
                new NomenclatureInStore {Id=97, StoreId=3, NomenclatureId=12, FeaturesSet=92, Amount=5},
                new NomenclatureInStore {Id=98, StoreId=1, NomenclatureId=12, FeaturesSet=93, Amount=2},
                new NomenclatureInStore {Id=99, StoreId=1, NomenclatureId=12, FeaturesSet=94, Amount=3},
                new NomenclatureInStore {Id=100, StoreId=3, NomenclatureId=12, FeaturesSet=95, Amount=11},
                new NomenclatureInStore {Id=101, StoreId=3, NomenclatureId=12, FeaturesSet=96, Amount=12},
                new NomenclatureInStore {Id=102, StoreId=2, NomenclatureId=12, FeaturesSet=97, Amount=10},
                new NomenclatureInStore {Id=103, StoreId=1, NomenclatureId=12, FeaturesSet=98, Amount=2},
                new NomenclatureInStore {Id=104, StoreId=1, NomenclatureId=12, FeaturesSet=99, Amount=10},
                new NomenclatureInStore {Id=105, StoreId=2, NomenclatureId=12, FeaturesSet=100, Amount=9},

            };
            nomenclatureinstores.ForEach(x => context.NomenclatureInStores.Add(x));
            context.SaveChanges();
        }
    }

}