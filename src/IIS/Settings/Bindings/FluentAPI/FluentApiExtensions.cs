namespace Cake.IIS.Settings.Bindings.FluentAPI
{
    /// <summary>
    /// Contains extension methods to configure bindings created by <see cref="IISBindings"/>
    /// </summary>
    public static class FluentApiExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="binding"></param>
        /// <param name="hostName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SetHostName<T>(this T binding, string hostName)
            where T : IHostBindingSettings
        {
            binding.HostName = hostName;
            return binding;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binding"></param>
        /// <param name="ipAddress"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SetIpAddress<T>(this T binding, string ipAddress)
            where T : IIpAddressBindingSettings
        {
            binding.IpAddress = ipAddress;
            return binding;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binding"></param>
        /// <param name="port"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SetPort<T>(this T binding, int port)
            where T : IPortBindingSettings
        {
            binding.Port = port;
            return binding;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binding"></param>
        /// <param name="certificateStoreName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SetCertificateStoreName<T>(this T binding, string certificateStoreName)
            where T : ICertificateBindingSettings
        {
            binding.CertificateStoreName = certificateStoreName;
            return binding;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binding"></param>
        /// <param name="certificateHash"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SetCertificateHash<T>(this T binding, byte[] certificateHash)
            where T : ICertificateBindingSettings
        {
            binding.CertificateHash = certificateHash;
            return binding;
        }
    }
}