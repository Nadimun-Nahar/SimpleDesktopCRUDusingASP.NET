﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace EFCustomerProjectDesktop
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class DBModelsContainer : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new DBModelsContainer object using the connection string found in the 'DBModelsContainer' section of the application configuration file.
        /// </summary>
        public DBModelsContainer() : base("name=DBModelsContainer", "DBModelsContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new DBModelsContainer object.
        /// </summary>
        public DBModelsContainer(string connectionString) : base(connectionString, "DBModelsContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new DBModelsContainer object.
        /// </summary>
        public DBModelsContainer(EntityConnection connection) : base(connection, "DBModelsContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
    }

    #endregion

}