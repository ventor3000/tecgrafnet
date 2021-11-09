using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tecgraf
{
    public class ButtonCBStatusMarshaller : ICustomMarshaler
    {
        static ButtonCBStatusMarshaller static_instance;

        public IntPtr MarshalManagedToNative(object managedObj)
        {
            return IntPtr.Zero; // we dont use this

            
        }

        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            string str=Marshal.PtrToStringUTF8(pNativeData);
            return new ModifierStatus(str);
            
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {
        }

        public void CleanUpManagedData(object managedObj)
        {
        }

        public int GetNativeDataSize()
        {
            return -1;
        }

        public static ICustomMarshaler GetInstance(string cookie)
        {
            if (static_instance == null)
            {
                return static_instance = new ButtonCBStatusMarshaller();
            }
            return static_instance;
        }
    }

    
}
