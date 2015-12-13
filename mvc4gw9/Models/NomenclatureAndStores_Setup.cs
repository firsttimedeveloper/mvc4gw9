using System;
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
                new Group {Id=9, Name="Одежда", ParentGroupId = 2},
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
                new FeaturesSet {Id=13, Name="gray 41"}
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
            };
            nomenclatureinstores.ForEach(x => context.NomenclatureInStores.Add(x));
            context.SaveChanges();
        }
    }

}