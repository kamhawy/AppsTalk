using System;
using System.Runtime.Serialization;
using System.Reflection;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// AppsTalk Deserialization Binder
    /// </summary>
    public sealed class AppsTalkDeserializationBinder : SerializationBinder
    {
        #region Members

        private string _DestinationAssembly = null; 

        #endregion

        #region Constructors
        
        public AppsTalkDeserializationBinder()
            : base()
        {

        }

        public AppsTalkDeserializationBinder(string pDestinationAssembly)
            : base()
        {
            this._DestinationAssembly = pDestinationAssembly;
        } 

        #endregion

        #region Overrides

        /// <summary>
        /// Bind To Type
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public override Type BindToType(string assemblyName, string typeName)
        {
            Type typeToDeserialize = null;

            try
            {
                if (assemblyName.Contains(".PhaseII"))
                {
                    assemblyName = assemblyName.Replace(".PhaseII", "");
                }

                if (typeName.Contains(".PhaseII"))
                {
                    typeName = typeName.Replace(".PhaseII", "");
                }

                typeToDeserialize = Type.GetType(typeName);
                                

                //else
                //{
                //    typeToDeserialize = Type.GetType(typeName);
                //}
                //typeToDeserialize = Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));
                //typeToDeserialize = Type.GetType(String.Format("{0}, {1}", typeName, this._DestinationAssembly));
                //typeToDeserialize = Type.GetType(typeName);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return typeToDeserialize;
        }

        #endregion
    }
}