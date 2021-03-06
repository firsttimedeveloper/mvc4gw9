﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;

namespace mvc4gw9.Models
{
    public class DAL
    {
        public static List<Group> GetGroup(int parentGroupId)
        {
            using (DBContext db = new DBContext())
            {
                return db.Groups.Where(x => x.ParentGroupId == parentGroupId && x.Id!=1).ToList();
            }
        }

        public static int GetGroupId(int nomenclatureId)
        {
            using (DBContext db = new DBContext())
            {
                return db.Nomenclature.Find(nomenclatureId).GroupId;
            }
        }
        
        public static Product GetProduct(int NomenclatureId, int FeaturesSetId)
        {
            Product product = new Product();
            List<string> gallery = new List<string>();

            using (DBContext db = new DBContext())
            {

                product.Id = NomenclatureId;
                product.Name = db.Nomenclature.Find(NomenclatureId).Name.ToString();
                product.Description = db.Nomenclature.Find(NomenclatureId).Description;

                int counter = 1;
                string path = AppDomain.CurrentDomain.BaseDirectory + @"/Content/nomenclature/pictures_small/";
                string filename = db.NomenclatureViews.FirstOrDefault(x => x.NomenclatureId == NomenclatureId && x.FeaturesSetId == FeaturesSetId).Image.ToString() + counter + ".jpg";

                product.Image = filename;

                while (File.Exists(path + filename))
                {
                    gallery.Add(filename);
                    counter++;
                    filename = db.NomenclatureViews.FirstOrDefault(x => x.NomenclatureId == NomenclatureId && x.FeaturesSetId == FeaturesSetId).Image.ToString() + counter + ".jpg";
                }

                product.Gallery = gallery;

                List<Parameter> parameters = new List<Parameter>();
                for (int i = 0; i < 2; i++)
                {
                    Parameter par = new Parameter();
                    par.Id = i + 1;
                    par.Name = db.Characteristics.Find(i + 1).Name;
                    par.Values = new List<string>();
                    par.SelectedValue = string.Empty;
                    parameters.Add(par);
                }
                product.Parameters = parameters;
                
                List<int> FeaturesSets = db.NomenclatureInStores.Where(x => x.NomenclatureId == NomenclatureId && x.Amount > 0).Select(x => x.FeaturesSet).ToList();
                foreach (var item in FeaturesSets)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        product.Parameters[i].SelectedValue = db.FeaturesOfNomenclatures.FirstOrDefault(x => x.FeaturesSetId == FeaturesSetId && x.CharacteristicId == (i + 1)).Value;
                        product.Parameters[i].Values.AddRange(db.FeaturesOfNomenclatures.Where(x => x.CharacteristicId == (i+1) && x.FeaturesSetId == item).Select(x => x.Value).ToList());
                    }
                }

                for (int i = 0; i < 2; i++)
                {                    
                    List<string> _values = new List<string>();

                    for (int k = 0; k < product.Parameters[i].Values.Count; k++)
                    {
                        if (_values == null)
                        {
                            _values = new List<string>() { product.Parameters[i].Values[k] };
                        }
                        else
                        {
                            if (!_values.Exists(x => x == product.Parameters[i].Values[k])) _values.Add(product.Parameters[i].Values[k]);
                        }

                    }

                    product.Parameters[i].Values = _values;
                }

                string currentParameters = string.Empty;
                List<Characteristic> characteristics = new List<Characteristic>();
                characteristics = db.Characteristics.ToList();
                foreach (Characteristic charactericstic in characteristics)
                    currentParameters += charactericstic.Name + "=" + db.FeaturesOfNomenclatures.FirstOrDefault(x => x.FeaturesSetId == FeaturesSetId && x.CharacteristicId == charactericstic.Id).Value + " ";

                product.currentParameters = currentParameters.Substring(0, currentParameters.Count() - 1);

            }

            return product;
        }

        public static List<Product> GetProducts(int GroupId)
        {
            List<Product> products = new List<Product>();
            using (DBContext db = new DBContext())
            {
                List<int> _nomenclatureIds = db.NomenclatureInStores.Where(x => x.Amount > 0).Select(x => x.NomenclatureId).ToList();
                List<int> nomenclatureIds = new List<int>();

                foreach (int _nomenclatureId in _nomenclatureIds)
                {
                    bool a = nomenclatureIds.Exists(x => x == _nomenclatureId);
                    if (!nomenclatureIds.Exists(x => x == _nomenclatureId)) nomenclatureIds.Add(_nomenclatureId);
                }

                foreach (int nomenclatureId in nomenclatureIds)
                {
                    Product product = new Product();
                    product.Id = nomenclatureId;
                    product.Name = db.Nomenclature.Find(nomenclatureId).Name;
                    product.Image = db.NomenclatureViews.FirstOrDefault(x => x.NomenclatureId == nomenclatureId).Image + "1.jpg";
                    product.currentParameters = db.NomenclatureInStores.FirstOrDefault(x => x.NomenclatureId == nomenclatureId && x.Amount > 0).FeaturesSet.ToString();

                    if (db.Nomenclature.Find(nomenclatureId).GroupId == GroupId) products.Add(product);
                }
            }

            return products;
        }

        public static ShoppingBasketAddPageContent GetProductInStores(int nomenclatureId, int featuresSetId)
        {
            using (DBContext db = new DBContext())
            {
                var entities = from A in db.NomenclatureInStores
                               where (A.NomenclatureId == nomenclatureId && A.FeaturesSet == featuresSetId)
                               join B in db.Stores on A.StoreId equals B.Id
                               select new
                                   {
                                        StoreName = B.Name,
                                        StoreAddress = B.Address,
                                        Amount = A.Amount
                                   };

                List<ProductInStore> productInStores = new List<ProductInStore>();
                foreach (var item in entities)
                {
                    ProductInStore productInStore = new ProductInStore();
                    productInStore.StoreName = item.StoreName;
                    productInStore.StoreAddress = item.StoreAddress;
                    productInStore.ProductAmount = item.Amount;
                    productInStores.Add(productInStore);                  
                }

                ShoppingBasketAddPageContent product = new ShoppingBasketAddPageContent();
                product.ProductName = db.Nomenclature.Find(nomenclatureId).Name.ToString();
                product.ProductFeaturesSet = db.FeaturesSets.Find(featuresSetId).Name.ToString();
                string path = AppDomain.CurrentDomain.BaseDirectory + @"/Content/nomenclature/pictures/";
                string filename = db.NomenclatureViews.FirstOrDefault(x => x.NomenclatureId == nomenclatureId && x.FeaturesSetId == featuresSetId).Image.ToString() + "1.jpg";
                product.ProductImage = filename;
                product.ProductInStores = productInStores;

                return product;
            }
        }

        public static string GetNewCurentParametersString(string parameter, string value, string parametersString)
        {
            string[] parameters = parametersString.Split((char)32);
            int k = parameters.Count();
            string[] parameterName = new string[k];
            string newCurrentParametersString = string.Empty;
            for (int i = 0; i < k; i++)
            {
                parameterName[i] = parameters[i].Split('=')[0];
                if (parameterName[i] == parameter)
                {
                    newCurrentParametersString += parameter + "=" + value;
                }
                else
                {
                    newCurrentParametersString += parameters[i];
                }
            }
            return newCurrentParametersString;
        }

        public static int GetFeaturesSetId(int nomenclatureId, string parametersString)
        {
            string[] parameters = parametersString.Split((char)32);
            int k = parameters.Count();
            string[] parameterName = new string[k];
            string[] parameterValue = new string[k];
            for (int i = 0; i < k; i++)
            {
                parameterName[i] = parameters[i].Split('=')[0];
                parameterValue[i] = parameters[i].Split('=')[1];

            }

            List<FeaturesOfNomenclature> featuresOfNomenclature = new List<FeaturesOfNomenclature>();
            List<FeaturesOfNomenclature> featuresOfNomenclature_buffer = new List<FeaturesOfNomenclature>();
            List<FeaturesOfNomenclature> featuresOfNomenclature_add = new List<FeaturesOfNomenclature>();
            List<int> featuresOfNomenclatureId = new List<int>();

            using (DBContext db = new DBContext())
            {
                featuresOfNomenclature = db.FeaturesOfNomenclatures.ToList();

                for (int i = 0; i < k; i++)
                {
                    string parametername = parameterName[i];
                    int characteristicId = db.Characteristics.FirstOrDefault(x => x.Name == parametername).Id;
                    featuresOfNomenclatureId = featuresOfNomenclature.Where(x => x.CharacteristicId == characteristicId && x.Value == parameterValue[i]).Select(x => x.FeaturesSetId).ToList();

                    foreach (int id in featuresOfNomenclatureId)
                    {
                        featuresOfNomenclature_add = featuresOfNomenclature.Where(x => x.FeaturesSetId == id && x.CharacteristicId != characteristicId).ToList();
                        featuresOfNomenclature_buffer.AddRange(featuresOfNomenclature_add);
                    }
                    featuresOfNomenclature = featuresOfNomenclature_buffer;
                }

                int _featuresOfNomenclatureId = (featuresOfNomenclatureId.Count() == 0) ? 0 : featuresOfNomenclatureId[0];
                if (db.NomenclatureInStores.Where(x => x.NomenclatureId == nomenclatureId && x.FeaturesSet == _featuresOfNomenclatureId && x.Amount > 0).ToList().Count == 0)
                {
                    for (int i = 0; i < k; i++)
                    {
                        parameterName[i] = parameters[i].Split('=')[0];
                        parameterValue[i] = parameters[i].Split('=')[1];
                    }

                    featuresOfNomenclature = db.FeaturesOfNomenclatures.ToList();
                    featuresOfNomenclature_buffer = new List<FeaturesOfNomenclature>();

                    for (int i = 0; i < k; i++)
                    {
                        string parametername = parameterName[i];
                        int characteristicId = db.Characteristics.FirstOrDefault(x => x.Name == parametername).Id;
                        featuresOfNomenclatureId = featuresOfNomenclature.Where(x => x.CharacteristicId == characteristicId && x.Value == parameterValue[i]).Select(x => x.FeaturesSetId).ToList();

                        foreach (int id in featuresOfNomenclatureId)
                        {
                            featuresOfNomenclature_add = featuresOfNomenclature.Where(x => x.FeaturesSetId == id && x.CharacteristicId != characteristicId).ToList();
                            featuresOfNomenclature_buffer.AddRange(featuresOfNomenclature_add);
                        }
                        featuresOfNomenclature = featuresOfNomenclature_buffer;
                    }
                }
            }
            return featuresOfNomenclatureId[0];
        
        }

        public static int GetNewFeaturesSetId(int NomenclatureId, string parameter, string value, string parametersString)
        {
            string[] parameters = parametersString.Split((char)32);
            int k = parameters.Count();
            string[] parameterName = new string[k];
            string[] parameterValue = new string[k];
            for (int i = 0; i < k; i++)
            {
                parameterName[i] = parameters[i].Split('=')[0];
                if (parameterName[i] == parameter)
                {
                    parameterValue[i] = value;
                }
                else
                {
                    parameterValue[i] = parameters[i].Split('=')[1];
                }
            }

            List<FeaturesOfNomenclature> featuresOfNomenclature = new List<FeaturesOfNomenclature>();
            List<FeaturesOfNomenclature> featuresOfNomenclature_buffer = new List<FeaturesOfNomenclature>();
            List<FeaturesOfNomenclature> featuresOfNomenclature_add = new List<FeaturesOfNomenclature>();
            List<int> featuresOfNomenclatureId = new List<int>();

            using (DBContext db = new DBContext())
            {                
                featuresOfNomenclature = db.FeaturesOfNomenclatures.ToList();

                for (int i = 0; i < k; i++)
                {
                    string parametername = parameterName[i];
                    int characteristicId = db.Characteristics.FirstOrDefault(x => x.Name == parametername).Id;
                    featuresOfNomenclatureId = featuresOfNomenclature.Where(x => x.CharacteristicId == characteristicId && x.Value == parameterValue[i]).Select(x => x.FeaturesSetId).ToList();

                    foreach (int id in featuresOfNomenclatureId)
                    {
                        featuresOfNomenclature_add = featuresOfNomenclature.Where(x => x.FeaturesSetId == id && x.CharacteristicId != characteristicId).ToList();
                        featuresOfNomenclature_buffer.AddRange(featuresOfNomenclature_add);
                    }
                    featuresOfNomenclature = featuresOfNomenclature_buffer;
                }

                int _featuresOfNomenclatureId = (featuresOfNomenclatureId.Count()==0) ? 0:featuresOfNomenclatureId[0];              
                if (db.NomenclatureInStores.Where(x => x.NomenclatureId == NomenclatureId && x.FeaturesSet == _featuresOfNomenclatureId && x.Amount > 0).ToList().Count == 0)
                {
                    for (int i = 0; i < k; i++)
                    {
                        parameterName[i] = parameters[i].Split('=')[0];
                        parameterValue[i] = parameters[i].Split('=')[1];
                    }

                    featuresOfNomenclature = db.FeaturesOfNomenclatures.ToList();
                    featuresOfNomenclature_buffer = new List<FeaturesOfNomenclature>();

                    for (int i = 0; i < k; i++)
                    {
                        string parametername = parameterName[i];
                        int characteristicId = db.Characteristics.FirstOrDefault(x => x.Name == parametername).Id;
                        featuresOfNomenclatureId = featuresOfNomenclature.Where(x => x.CharacteristicId == characteristicId && x.Value == parameterValue[i]).Select(x => x.FeaturesSetId).ToList();

                        foreach (int id in featuresOfNomenclatureId)
                        {
                            featuresOfNomenclature_add = featuresOfNomenclature.Where(x => x.FeaturesSetId == id && x.CharacteristicId != characteristicId).ToList();
                            featuresOfNomenclature_buffer.AddRange(featuresOfNomenclature_add);
                        }
                        featuresOfNomenclature = featuresOfNomenclature_buffer;
                    }
                }
            }
            return featuresOfNomenclatureId[0];
        }

        public static List<Group> GetPath(int GroupId)
        {        
            using (DBContext db= new DBContext())
            {
                List<Group> groups = new List<Group>();
                while(GroupId!=1)
                {
                    groups.Add(db.Groups.Find(GroupId));
                    GroupId = db.Groups.Find(GroupId).ParentGroupId;
                }
                groups.Add(db.Groups.Find(1));
                groups.Reverse();
                return groups;                
            }
        }

        public static List<Branch> GetBranches(int GroupId)
        {
            List<Branch> branches = new List<Branch>();
            using (DBContext db = new DBContext())
            {
                if (db.Groups.Where(x => x.ParentGroupId == GroupId && x.Id!=1).Count()==0)
                {
                    Branch branch = new Branch();
                    branch.Group = db.Groups.Find(db.Groups.Find(GroupId).ParentGroupId);
                    branch.Subgroups = db.Groups.Where(x => x.ParentGroupId == branch.Group.Id).ToList();
                    branches.Add(branch);
                    return branches;
                }
                else
                {
                    int rootGroupId = db.Groups.Find(db.Groups.Find(GroupId).ParentGroupId).ParentGroupId;
                    List<Group> groups = new List<Group>();
                    groups = db.Groups.Where(x => x.ParentGroupId == GroupId && x.Id!=1).ToList();
                    int subgroups_counter=0;
                    foreach (Group group in groups)
                    {
                        Branch branch = new Branch();
                        branch.Group = group;
                        branch.Subgroups = db.Groups.Where(x => x.ParentGroupId == group.Id).ToList();
                        branches.Add(branch);

                        subgroups_counter += branch.Subgroups.Count;
                    }
                    if (subgroups_counter == 0)
                    {
                        branches.Clear();
                        Branch branch = new Branch();
                        branch.Group = db.Groups.Find(GroupId);
                        branch.Subgroups = db.Groups.Where(x => x.ParentGroupId == GroupId).ToList();
                        branches.Add(branch);
                        return branches;
                    }
                    else
                    {
                        return branches;
                    }
                }
            }
        }

        public static bool HasSubgroup(int GroupId)
        {
            using (DBContext db = new DBContext())
            {
                if (db.Groups.Where(x => x.ParentGroupId == GroupId).ToList().Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }

    }
}