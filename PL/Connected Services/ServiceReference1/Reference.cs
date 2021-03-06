//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Result", Namespace="http://schemas.datacontract.org/2004/07/SL")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Materia))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Semestre))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Exception))]
    public partial class Result : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool CorrectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Exception ExField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ObjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object[] ObjectsField;
        
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
        public bool Correct {
            get {
                return this.CorrectField;
            }
            set {
                if ((this.CorrectField.Equals(value) != true)) {
                    this.CorrectField = value;
                    this.RaisePropertyChanged("Correct");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Exception Ex {
            get {
                return this.ExField;
            }
            set {
                if ((object.ReferenceEquals(this.ExField, value) != true)) {
                    this.ExField = value;
                    this.RaisePropertyChanged("Ex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Object {
            get {
                return this.ObjectField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectField, value) != true)) {
                    this.ObjectField = value;
                    this.RaisePropertyChanged("Object");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] Objects {
            get {
                return this.ObjectsField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectsField, value) != true)) {
                    this.ObjectsField = value;
                    this.RaisePropertyChanged("Objects");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IMateria")]
    public interface IMateria {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMateria/Add", ReplyAction="http://tempuri.org/IMateria/AddResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Semestre))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL.ServiceReference1.Result))]
        PL.ServiceReference1.Result Add(ML.Materia materia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMateria/Add", ReplyAction="http://tempuri.org/IMateria/AddResponse")]
        System.Threading.Tasks.Task<PL.ServiceReference1.Result> AddAsync(ML.Materia materia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMateria/Update", ReplyAction="http://tempuri.org/IMateria/UpdateResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Semestre))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL.ServiceReference1.Result))]
        PL.ServiceReference1.Result Update(ML.Materia materia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMateria/Update", ReplyAction="http://tempuri.org/IMateria/UpdateResponse")]
        System.Threading.Tasks.Task<PL.ServiceReference1.Result> UpdateAsync(ML.Materia materia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMateria/Delete", ReplyAction="http://tempuri.org/IMateria/DeleteResponse")]
        PL.ServiceReference1.Result Delete(int IdMateria);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMateria/Delete", ReplyAction="http://tempuri.org/IMateria/DeleteResponse")]
        System.Threading.Tasks.Task<PL.ServiceReference1.Result> DeleteAsync(int IdMateria);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMateriaChannel : PL.ServiceReference1.IMateria, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MateriaClient : System.ServiceModel.ClientBase<PL.ServiceReference1.IMateria>, PL.ServiceReference1.IMateria {
        
        public MateriaClient() {
        }
        
        public MateriaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MateriaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MateriaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MateriaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PL.ServiceReference1.Result Add(ML.Materia materia) {
            return base.Channel.Add(materia);
        }
        
        public System.Threading.Tasks.Task<PL.ServiceReference1.Result> AddAsync(ML.Materia materia) {
            return base.Channel.AddAsync(materia);
        }
        
        public PL.ServiceReference1.Result Update(ML.Materia materia) {
            return base.Channel.Update(materia);
        }
        
        public System.Threading.Tasks.Task<PL.ServiceReference1.Result> UpdateAsync(ML.Materia materia) {
            return base.Channel.UpdateAsync(materia);
        }
        
        public PL.ServiceReference1.Result Delete(int IdMateria) {
            return base.Channel.Delete(IdMateria);
        }
        
        public System.Threading.Tasks.Task<PL.ServiceReference1.Result> DeleteAsync(int IdMateria) {
            return base.Channel.DeleteAsync(IdMateria);
        }
    }
}
