//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace Restrike.GitHubIntegration.EFDAL
{
	#region IContextStartup
    public interface IContextStartup
    {
        string Modifier { get; }
        bool AllowLazyLoading { get; }
        int CommandTimeout { get; }
    }
	#endregion

	#region ContextStartup

	/// <summary>
	/// This object holds the initialization information for a context
	/// </summary>
	[System.CodeDom.Compiler.GeneratedCode("nHydrate", "0.0.0")]
	public partial class ContextStartup : IContextStartup, ICloneable
	{
		protected internal string DebugInfo { get; set; }
		protected internal bool DefaultTimeout { get; private set; }

		/// <summary>
		/// Creates a new instance of the ContextStartup object
		/// </summary>
		public ContextStartup(string modifier)
		{
			this.CommandTimeout = 30;
			this.Modifier = modifier;
			this.AllowLazyLoading = true;
			this.DefaultTimeout = true;
		}

		/// <summary>
		/// Creates a new instance of the ContextStartup object
		/// </summary>
		public ContextStartup(string modifier, bool allowLazyLoading) :
			this(modifier)
		{
			this.AllowLazyLoading = allowLazyLoading;
			this.DefaultTimeout = true;
		}

		/// <summary>
		/// Creates a new instance of the ContextStartup object
		/// </summary>
		public ContextStartup(string modifier, bool allowLazyLoading, int commandTimeout) :
			this(modifier, allowLazyLoading)
		{
			this.CommandTimeout = commandTimeout;
			this.DefaultTimeout = false;
		}

		/// <summary>
		/// The modifier string used for auditing
		/// </summary>
		public virtual string Modifier { get; protected internal set; }

		/// <summary>
		/// Determines if relationships can be walked via 'Lazy Loading'
		/// </summary>
		public virtual bool AllowLazyLoading { get; protected internal set; }

		/// <summary>
		/// Determines the database timeout value in seconds
		/// </summary>
		public virtual int CommandTimeout { get; protected internal set; }

		/// <summary />
		object ICloneable.Clone()
		{
			return (ContextStartup)this.MemberwiseClone();
		}

	}

	#endregion

	#region TenantContextStartup
    /// <summary>
    /// Initialization object used for tenant based data contexts
    /// </summary>
    public partial class TenantContextStartup : ContextStartup
    {
        public TenantContextStartup(string modifier, string tenantId)
            : base(modifier)
        {
            if (string.IsNullOrEmpty(tenantId))
                throw new Exceptions.ContextConfigurationException("The tenant ID must be set!");

            this.TenantId = tenantId;
        }

        public TenantContextStartup(string modifier, string tenantId, bool allowLazyLoading, int commandTimeout)
            : base(modifier, allowLazyLoading, commandTimeout)
        {
            if (string.IsNullOrEmpty(tenantId))
                throw new Exceptions.ContextConfigurationException("The tenant ID must be set!");

            this.TenantId = tenantId;
        }

        public string TenantId { get; }
    }
	#endregion

}

