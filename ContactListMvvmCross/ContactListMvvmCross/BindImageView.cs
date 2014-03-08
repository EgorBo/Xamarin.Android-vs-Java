using System;
using Android.Widget;
using Android.Content;
using Android.Util;
using Android.Runtime;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace ContactListMvvmCross
{
    public class BindImageView : ImageView
    {     

        public BindImageView(Android.Content.Context context) :base(context)
        {

        }

        public BindImageView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {

        }

           


        public BindImageView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }


        public BindImageView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
        }


        public IMvxBindingContext BindingContext
        {
            get;
            set;
        }


        public int Res 
        {
            set 
            {
                SetImageResource(value);
            }
        }

    }
}

