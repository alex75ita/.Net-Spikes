﻿//using monei.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using monei.Core.Entities;
using NHibernate.Cfg;
using System.Reflection;

namespace Spikes.NHibernate
{
    public class CategoryRepository
    {
        private ISessionFactory sessionFactory;
        public CategoryRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        public IEnumerable<Category> List()
        {
            IEnumerable<Category> categories = new List<Category>();

            using (ISession session = OpenSession())
            {
                categories = session.Query<Category>().ToList();
            }

            monei.Core.Entities.Subcategory sub = new monei.Core.Entities.Subcategory();

            return categories;
        }

        public IEnumerable<Category> List_usingFetch()
        {
            IEnumerable<Category> categories = new List<Category>();

            using (ISession session = OpenSession())
            {
                //ICriteria criteria = session.CreateCriteria<Category>();
                //criteria.SetFetchMode("", FetchMode.)
                categories = session.Query<Category>()
                    //.FetchMany<Category, Subcategory>(c => c.Subcategories)                    
                    .Fetch(c => c.Subcategories)
                    .ToList();
            }

            monei.Core.Entities.Subcategory sub = new monei.Core.Entities.Subcategory();

            return categories;
        }

        public IEnumerable<Category> List_usingFetchMany()
        {
            IEnumerable<Category> categories = new List<Category>();

            using (ISession session = OpenSession())
            {
                //ICriteria criteria = session.CreateCriteria<Category>();
                //criteria.SetFetchMode("", FetchMode.)
                categories = session.Query<Category>()
                    .FetchMany<Category, Subcategory>(c => c.Subcategories)                                        
                    .ToList();
            }

            monei.Core.Entities.Subcategory sub = new monei.Core.Entities.Subcategory();

            return categories;
        }

        public static void CheckCategoryMapping()
        {
            Configuration configuration = new Configuration();
            configuration.AddAssembly(Assembly.GetAssembly(typeof(monei.Core.Entities.Category)));
            configuration.BuildSessionFactory();
        }

        private ISession OpenSession()
        {
            return sessionFactory.OpenSession();
        }
    }
}
