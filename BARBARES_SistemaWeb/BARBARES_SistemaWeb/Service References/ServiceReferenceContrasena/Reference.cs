﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BARBARES_SistemaWeb.ServiceReferenceContrasena {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Contrasena", Namespace="http://schemas.datacontract.org/2004/07/BARABARES_Services.DTO")]
    [System.SerializableAttribute()]
    public partial class Contrasena : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ActivoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaFinField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaInicioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdContrasenaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValorField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Activo {
            get {
                return this.ActivoField;
            }
            set {
                if ((this.ActivoField.Equals(value) != true)) {
                    this.ActivoField = value;
                    this.RaisePropertyChanged("Activo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaFin {
            get {
                return this.FechaFinField;
            }
            set {
                if ((this.FechaFinField.Equals(value) != true)) {
                    this.FechaFinField = value;
                    this.RaisePropertyChanged("FechaFin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaInicio {
            get {
                return this.FechaInicioField;
            }
            set {
                if ((this.FechaInicioField.Equals(value) != true)) {
                    this.FechaInicioField = value;
                    this.RaisePropertyChanged("FechaInicio");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdContrasena {
            get {
                return this.IdContrasenaField;
            }
            set {
                if ((this.IdContrasenaField.Equals(value) != true)) {
                    this.IdContrasenaField = value;
                    this.RaisePropertyChanged("IdContrasena");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Valor {
            get {
                return this.ValorField;
            }
            set {
                if ((object.ReferenceEquals(this.ValorField, value) != true)) {
                    this.ValorField = value;
                    this.RaisePropertyChanged("Valor");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseBD", Namespace="http://schemas.datacontract.org/2004/07/BARABARES_Services.DTO")]
    [System.SerializableAttribute()]
    public partial class ResponseBD : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FlujoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MensajeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Flujo {
            get {
                return this.FlujoField;
            }
            set {
                if ((object.ReferenceEquals(this.FlujoField, value) != true)) {
                    this.FlujoField = value;
                    this.RaisePropertyChanged("Flujo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Mensaje {
            get {
                return this.MensajeField;
            }
            set {
                if ((object.ReferenceEquals(this.MensajeField, value) != true)) {
                    this.MensajeField = value;
                    this.RaisePropertyChanged("Mensaje");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceContrasena.IContrasena_Services")]
    public interface IContrasena_Services {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContrasena_Services/selectAll_Contrasena", ReplyAction="http://tempuri.org/IContrasena_Services/selectAll_ContrasenaResponse")]
        BARBARES_SistemaWeb.ServiceReferenceContrasena.Contrasena[] selectAll_Contrasena();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContrasena_Services/selectAll_Contrasena", ReplyAction="http://tempuri.org/IContrasena_Services/selectAll_ContrasenaResponse")]
        System.Threading.Tasks.Task<BARBARES_SistemaWeb.ServiceReferenceContrasena.Contrasena[]> selectAll_ContrasenaAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContrasena_Services/add_Contrasena", ReplyAction="http://tempuri.org/IContrasena_Services/add_ContrasenaResponse")]
        BARBARES_SistemaWeb.ServiceReferenceContrasena.ResponseBD add_Contrasena(BARBARES_SistemaWeb.ServiceReferenceContrasena.Contrasena t);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContrasena_Services/add_Contrasena", ReplyAction="http://tempuri.org/IContrasena_Services/add_ContrasenaResponse")]
        System.Threading.Tasks.Task<BARBARES_SistemaWeb.ServiceReferenceContrasena.ResponseBD> add_ContrasenaAsync(BARBARES_SistemaWeb.ServiceReferenceContrasena.Contrasena t);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IContrasena_ServicesChannel : BARBARES_SistemaWeb.ServiceReferenceContrasena.IContrasena_Services, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Contrasena_ServicesClient : System.ServiceModel.ClientBase<BARBARES_SistemaWeb.ServiceReferenceContrasena.IContrasena_Services>, BARBARES_SistemaWeb.ServiceReferenceContrasena.IContrasena_Services {
        
        public Contrasena_ServicesClient() {
        }
        
        public Contrasena_ServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Contrasena_ServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Contrasena_ServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Contrasena_ServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public BARBARES_SistemaWeb.ServiceReferenceContrasena.Contrasena[] selectAll_Contrasena() {
            return base.Channel.selectAll_Contrasena();
        }
        
        public System.Threading.Tasks.Task<BARBARES_SistemaWeb.ServiceReferenceContrasena.Contrasena[]> selectAll_ContrasenaAsync() {
            return base.Channel.selectAll_ContrasenaAsync();
        }
        
        public BARBARES_SistemaWeb.ServiceReferenceContrasena.ResponseBD add_Contrasena(BARBARES_SistemaWeb.ServiceReferenceContrasena.Contrasena t) {
            return base.Channel.add_Contrasena(t);
        }
        
        public System.Threading.Tasks.Task<BARBARES_SistemaWeb.ServiceReferenceContrasena.ResponseBD> add_ContrasenaAsync(BARBARES_SistemaWeb.ServiceReferenceContrasena.Contrasena t) {
            return base.Channel.add_ContrasenaAsync(t);
        }
    }
}
