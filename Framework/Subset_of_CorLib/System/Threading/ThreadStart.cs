////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace System.Threading
{
    using System.Threading;

    // Define the delgate
    // NOTE: If you change the signature here, there is code in COMSynchronization
    //  that invokes this delegate in native.
    public delegate void ThreadStart();
}


