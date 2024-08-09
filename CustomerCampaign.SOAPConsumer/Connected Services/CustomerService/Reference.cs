﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CustomerService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SyncCustomersRq", Namespace="http://schemas.datacontract.org/2004/07/CustomerCampaign.SOAP.Models.Requests")]
    public partial class SyncCustomersRq : object
    {
        
        private CustomerService.Customer[] CustomersField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CustomerService.Customer[] Customers
        {
            get
            {
                return this.CustomersField;
            }
            set
            {
                this.CustomersField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Customer", Namespace="http://schemas.datacontract.org/2004/07/CustomerCampaign.Infrastructure.Models.Co" +
        "mmon")]
    public partial class Customer : object
    {
        
        private System.Nullable<System.DateTime> DateOfBirthField;
        
        private CustomerService.Address HomeAddressField;
        
        private string NameField;
        
        private string SSNField;
        
        private CustomerService.Address WorkAddressField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> DateOfBirth
        {
            get
            {
                return this.DateOfBirthField;
            }
            set
            {
                this.DateOfBirthField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CustomerService.Address HomeAddress
        {
            get
            {
                return this.HomeAddressField;
            }
            set
            {
                this.HomeAddressField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SSN
        {
            get
            {
                return this.SSNField;
            }
            set
            {
                this.SSNField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CustomerService.Address WorkAddress
        {
            get
            {
                return this.WorkAddressField;
            }
            set
            {
                this.WorkAddressField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Address", Namespace="http://schemas.datacontract.org/2004/07/CustomerCampaign.Infrastructure.Models.Co" +
        "mmon")]
    public partial class Address : object
    {
        
        private string CityField;
        
        private string StateField;
        
        private string StreetField;
        
        private string ZipField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string City
        {
            get
            {
                return this.CityField;
            }
            set
            {
                this.CityField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string State
        {
            get
            {
                return this.StateField;
            }
            set
            {
                this.StateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Street
        {
            get
            {
                return this.StreetField;
            }
            set
            {
                this.StreetField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Zip
        {
            get
            {
                return this.ZipField;
            }
            set
            {
                this.ZipField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AddCustomerRq", Namespace="http://schemas.datacontract.org/2004/07/CustomerCampaign.SOAP.Models.Requests")]
    public partial class AddCustomerRq : object
    {
        
        private System.Nullable<System.DateTime> DateOfBirthField;
        
        private CustomerService.Address HomeAddressField;
        
        private string NameField;
        
        private string SSNField;
        
        private CustomerService.Address WorkAddressField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> DateOfBirth
        {
            get
            {
                return this.DateOfBirthField;
            }
            set
            {
                this.DateOfBirthField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CustomerService.Address HomeAddress
        {
            get
            {
                return this.HomeAddressField;
            }
            set
            {
                this.HomeAddressField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SSN
        {
            get
            {
                return this.SSNField;
            }
            set
            {
                this.SSNField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CustomerService.Address WorkAddress
        {
            get
            {
                return this.WorkAddressField;
            }
            set
            {
                this.WorkAddressField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CustomerService.ICustomerService")]
    public interface ICustomerService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/SyncCustomers", ReplyAction="http://tempuri.org/ICustomerService/SyncCustomersResponse")]
        void SyncCustomers(CustomerService.SyncCustomersRq request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/SyncCustomers", ReplyAction="http://tempuri.org/ICustomerService/SyncCustomersResponse")]
        System.Threading.Tasks.Task SyncCustomersAsync(CustomerService.SyncCustomersRq request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/AddCustomer", ReplyAction="http://tempuri.org/ICustomerService/AddCustomerResponse")]
        void AddCustomer(CustomerService.AddCustomerRq request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/AddCustomer", ReplyAction="http://tempuri.org/ICustomerService/AddCustomerResponse")]
        System.Threading.Tasks.Task AddCustomerAsync(CustomerService.AddCustomerRq request);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface ICustomerServiceChannel : CustomerService.ICustomerService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class CustomerServiceClient : System.ServiceModel.ClientBase<CustomerService.ICustomerService>, CustomerService.ICustomerService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public CustomerServiceClient() : 
                base(CustomerServiceClient.GetDefaultBinding(), CustomerServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ICustomerService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CustomerServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(CustomerServiceClient.GetBindingForEndpoint(endpointConfiguration), CustomerServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CustomerServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(CustomerServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CustomerServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(CustomerServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CustomerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public void SyncCustomers(CustomerService.SyncCustomersRq request)
        {
            base.Channel.SyncCustomers(request);
        }
        
        public System.Threading.Tasks.Task SyncCustomersAsync(CustomerService.SyncCustomersRq request)
        {
            return base.Channel.SyncCustomersAsync(request);
        }
        
        public void AddCustomer(CustomerService.AddCustomerRq request)
        {
            base.Channel.AddCustomer(request);
        }
        
        public System.Threading.Tasks.Task AddCustomerAsync(CustomerService.AddCustomerRq request)
        {
            return base.Channel.AddCustomerAsync(request);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ICustomerService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ICustomerService))
            {
                return new System.ServiceModel.EndpointAddress("https://localhost:7030/CustomerService.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return CustomerServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ICustomerService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return CustomerServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ICustomerService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_ICustomerService,
        }
    }
}
