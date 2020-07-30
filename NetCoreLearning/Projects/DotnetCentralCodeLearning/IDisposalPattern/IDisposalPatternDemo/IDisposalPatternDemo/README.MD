Implementing the Dispose method is primarily for releasing unmanaged resources used by your code. When working with instance members that are IDisposable implementations, it's common to cascade Dispose calls. There are additional reasons for implementing Dispose, such as undoing something that was previously done. For example, freeing memory that was allocated, removing an item from a collection that was added, signaling the release of a lock that was acquired, and so on.

The .NET **garbage collector does not allocate or release unmanaged memory**. The pattern for disposing an object, referred to as the dispose pattern, imposes order on the lifetime of an object. The dispose pattern is used for objects that implement the IDisposable interface, and is common when interacting with file and pipe handles, registry handles, wait handles, or pointers to blocks of unmanaged memory. This is because the garbage collector is unable to reclaim unmanaged objects.

To help ensure that resources are always cleaned up appropriately, a Dispose method should be idempotent, such that it is callable multiple times without throwing an exception. Furthermore, subsequent invocations of Dispose should do nothing.

The code example provided for the GC.KeepAlive method shows how garbage collection can cause a finalizer to run, while an unmanaged reference to the object or its members is still in use. It may make sense to utilize GC.KeepAlive to make the object ineligible for garbage collection from the start of the current routine to the point where this method is called.
Safe handles

Writing code for an object's finalizer is a complex task that can cause problems if not done correctly. Therefore, we recommend that you construct System.Runtime.InteropServices.SafeHandle objects instead of implementing a finalizer.

A System.Runtime.InteropServices.SafeHandle is an abstract managed type that wraps an System.IntPtr that identifies an unmanaged resource. On Windows it might identify a handle while on Unix, a file descriptor. It provides all of the logic necessary to ensure that this resource is released once and only once, when the SafeHandle is disposed of or when all references to the SafeHandle have been dropped and the SafeHandle instance is finalized.

The System.Runtime.InteropServices.SafeHandle is an abstract base class. Derived classes provide specific instances for different kinds of handle. These derived classes validate what values for the System.IntPtr are considered invalid and how to actually free the handle. For example, SafeFileHandle derives from SafeHandle to wrap IntPtrs that identify open file handles/descriptors, and overrides its SafeHandle.ReleaseHandle() method to close it (via the close function on Unix or CloseHandle function on Windows). Most APIs in .NET libraries that create an unmanaged resource will wrap it in a SafeHandle and return that SafeHandle to you as needed, rather than handing back the raw pointer. In situations where you interact with an unmanaged component and get an IntPtr for an unmanaged resource, you can create your own SafeHandle type to wrap it. As a result, few non-SafeHandle types need to implement finalizers; most disposable pattern implementations only end up wrapping other managed resources, some of which may be SafeHandles.

The following derived classes in the Microsoft.Win32.SafeHandles namespace provide safe handles:

    The SafeFileHandle, SafeMemoryMappedFileHandle, and SafePipeHandle class, for files, memory mapped files, and pipes.
    The SafeMemoryMappedViewHandle class, for memory views.
    The SafeNCryptKeyHandle, SafeNCryptProviderHandle, and SafeNCryptSecretHandle classes, for cryptography constructs.
    The SafeRegistryHandle class, for registry keys.
    The SafeWaitHandle class, for wait handles.

Dispose() and Dispose(bool)

The IDisposable interface requires the implementation of a single parameterless method, Dispose. Also, any non-sealed class should have an additional Dispose(bool) overload method to be implemented:

    A public non-virtual (NonInheritable in Visual Basic) IDisposable.Dispose implementation that has no parameters.

    A protected virtual (Overridable in Visual Basic) Dispose method whose signature is:
    C#

    protected virtual void Dispose(bool disposing)
    {
    }

    Important

    The disposing parameter should be false when called from a finalizer, and true when called from the IDisposable.Dispose method. In other words, it is true when deterministically called and false when non-deterministically called.

The Dispose() method

Because the public, non-virtual (NonInheritable in Visual Basic), parameterless Dispose method is called by a consumer of the type, its purpose is to free unmanaged resources, perform general cleanup, and to indicate that the finalizer, if one is present, doesn't have to run. Freeing the actual memory associated with a managed object is always the domain of the garbage collector. Because of this, it has a standard implementation:
C#

public void Dispose()
{
   // Dispose of unmanaged resources.
   Dispose(true);
   // Suppress finalization.
   GC.SuppressFinalize(this);
}

The Dispose method performs all object cleanup, so the garbage collector no longer needs to call the objects' Object.Finalize override. Therefore, the call to the SuppressFinalize method prevents the garbage collector from running the finalizer. If the type has no finalizer, the call to GC.SuppressFinalize has no effect. Note that the actual cleanup is performed by the Dispose(bool) method overload.
The Dispose(bool) method overload

In the overload, the disposing parameter is a Boolean that indicates whether the method call comes from a Dispose method (its value is true) or from a finalizer (its value is false).

The body of the method consists of two blocks of code:

    A block that frees unmanaged resources. This block executes regardless of the value of the disposing parameter.

    A conditional block that frees managed resources. This block executes if the value of disposing is true. The managed resources that it frees can include:

        Managed objects that implement IDisposable. The conditional block can be used to call their Dispose implementation (cascade dispose). If you have used a derived class of System.Runtime.InteropServices.SafeHandle to wrap your unmanaged resource, you should call the SafeHandle.Dispose() implementation here.

        Managed objects that consume large amounts of memory or consume scarce resources. Assign large managed object references to null to make them more likely to be unreachable. This releases them faster than if they were reclaimed non-deterministically.

If the method call comes from a finalizer, only the code that frees unmanaged resources should execute. The implementer is responsible for ensuring the the false path doesn't interact with managed objects that may have been reclaimed. This is important because the order in which the garbage collector destroys managed objects during finalization is non-deterministic.
Cascade dispose calls

If your class owns a field or property, and its type implements IDisposable, the containing class itself should also implement IDisposable. A class that instantiates an IDisposable implementation and storing it as an instance member, is also responsible for its cleanup. This is to help ensure that the referenced disposable types are given the opportunity to deterministically perform clean up through the Dispose method. In this example, the class is sealed (or NotInheritable in Visual Basic).
C#

public sealed class Foo : IDisposable
{
    private readonly IDisposable _bar;

    public Foo()
    {
        _bar = new Bar();
    }

    public void Dispose()
    {
        _bar?.Dispose();
    }
}

Implement the dispose pattern

All non-sealed classes or (Visual Basic classes not modified as NotInheritable) should be considered a potential base class, because they could be inherited. If you implement the dispose pattern for any potential base class, you must provide the following:

    A Dispose implementation that calls the Dispose(bool) method.
    A Dispose(bool) method that performs the actual cleanup.
    Either a class derived from SafeHandle that wraps your unmanaged resource (recommended), or an override to the Object.Finalize method. The SafeHandle class provides a finalizer, so you do not have to write one yourself.

Important

It is possible for a base class to only reference managed objects, and implement the dispose pattern. In these cases, a finalizer is unnecessary. A finalizer is only required if you directly reference unmanaged resources.

Here's the general pattern for implementing the dispose pattern for a base class that uses a safe handle.
C#

using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

class BaseClass : IDisposable
{
    // To detect redundant calls
    private bool _disposed = false;

    // Instantiate a SafeHandle instance.
    private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

    // Public implementation of Dispose pattern callable by consumers.
    public void Dispose() => Dispose(true);

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
           // Dispose managed state (managed objects).
            _safeHandle?.Dispose();
        }

        _disposed = true;
    }
}

Note

The previous example uses a SafeFileHandle object to illustrate the pattern; any object derived from SafeHandle could be used instead. Note that the example does not properly instantiate its SafeFileHandle object.

Here's the general pattern for implementing the dispose pattern for a base class that overrides Object.Finalize.
C#

using System;

class BaseClass : IDisposable
{
    // To detect redundant calls
    private bool _disposed = false;

    ~BaseClass() => Dispose(false);

    // Public implementation of Dispose pattern callable by consumers.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            // TODO: dispose managed state (managed objects).
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

        _disposed = true;
    }
}

Tip

In C#, you create a finalizer by overriding Object.Finalize. In Visual Basic, this is done with Protected Overrides Sub Finalize().
Implement the dispose pattern for a derived class

A class derived from a class that implements the IDisposable interface shouldn't implement IDisposable, because the base class implementation of IDisposable.Dispose is inherited by its derived classes. Instead, to cleanup a derived class, you provide the following:

    A protected override void Dispose(bool) method that overrides the base class method and performs the actual cleanup of the derived class. This method must also call the base.Dispose(bool) (MyBase.Dispose(bool) in Visual Basic) method of the base class and pass its disposing status for the argument.
    Either a class derived from SafeHandle that wraps your unmanaged resource (recommended), or an override to the Object.Finalize method. The SafeHandle class provides a finalizer that frees you from having to code one. If you do provide a finalizer, it must call the Dispose(bool) overload with a disposing argument of false.

Here's the general pattern for implementing the dispose pattern for a derived class that uses a safe handle:
C#

using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

class DerivedClass : BaseClass
{
    // To detect redundant calls
    private bool _disposed = false;

    // Instantiate a SafeHandle instance.
    private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

    // Protected implementation of Dispose pattern.
    protected override void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
           // Dispose managed state (managed objects).
            _safeHandle?.Dispose();
        }

        _disposed = true;

        // Call base class implementation.
        base.Dispose(disposing);
    }
}

Note

The previous example uses a SafeFileHandle object to illustrate the pattern; any object derived from SafeHandle could be used instead. Note that the example does not properly instantiate its SafeFileHandle object.

Here's the general pattern for implementing the dispose pattern for a derived class that overrides Object.Finalize:
C#

using System;

class DerivedClass : BaseClass
{
    // To detect redundant calls
    bool _disposed = false;

    ~DerivedClass() => Dispose(false);

    // Protected implementation of Dispose pattern.
    protected override void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            // TODO: dispose managed state (managed objects).
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.
        _disposed = true;

        // Call the base class implementation.
        base.Dispose(disposing);
    }
}

Implement the dispose pattern with safe handles

The following example illustrates the dispose pattern for a base class, DisposableStreamResource, that uses a safe handle to encapsulate unmanaged resources. It defines a DisposableStreamResource class that uses a SafeFileHandle to wrap a Stream object that represents an open file. The class also includes a single property, Size, that returns the total number of bytes in the file stream.
C#

using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

public class DisposableStreamResource : IDisposable
{
    // Define constants.
    protected const uint GENERIC_READ = 0x80000000;
    protected const uint FILE_SHARE_READ = 0x00000001;
    protected const uint OPEN_EXISTING = 3;
    protected const uint FILE_ATTRIBUTE_NORMAL = 0x80;
    private const int INVALID_FILE_SIZE = unchecked((int)0xFFFFFFFF);

    // Define Windows APIs.
    [DllImport("kernel32.dll", EntryPoint = "CreateFileW", CharSet = CharSet.Unicode)]
    protected static extern SafeFileHandle CreateFile(
        string lpFileName, uint dwDesiredAccess,
        uint dwShareMode, IntPtr lpSecurityAttributes,
        uint dwCreationDisposition, uint dwFlagsAndAttributes,
        IntPtr hTemplateFile);

    [DllImport("kernel32.dll")]
    private static extern int GetFileSize(
        SafeFileHandle hFile, out int lpFileSizeHigh);

    // Define locals.
    private bool _disposed = false;
    private readonly SafeFileHandle _safeHandle;
    private readonly int _upperWord;

    public DisposableStreamResource(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            throw new ArgumentException("The fileName cannot be null or an empty string");
        }

        _safeHandle = CreateFile(
            fileName, GENERIC_READ, FILE_SHARE_READ, IntPtr.Zero,
            OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);

        // Get file size.
        Size = GetFileSize(_safeHandle, out _upperWord);
        if (Size == INVALID_FILE_SIZE)
        {
            Size = -1;
        }
        else if (_upperWord > 0)
        {
            Size = (((long)_upperWord) << 32) + Size;
        }
    }

    public long Size { get; }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        // Dispose of managed resources here.
        if (disposing)
        {
            _safeHandle?.Dispose();
        }

        // Dispose of any unmanaged resources not wrapped in safe handles.

        _disposed = true;
    }
}

Implement the dispose pattern for a derived class with safe handles

The following example illustrates the dispose pattern for a derived class, DisposableStreamResource2, that inherits from the DisposableStreamResource class presented in the previous example. The class adds an additional method, WriteFileInfo, and uses a SafeFileHandle object to wrap the handle of the writable file.
C#

using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

public class DisposableStreamResource2 : DisposableStreamResource
{
    // Define additional constants.
    protected const uint GENERIC_WRITE = 0x40000000;
    protected const uint OPEN_ALWAYS = 4;

    // Define additional APIs.
    [DllImport("kernel32.dll")]
    protected static extern bool WriteFile(
        SafeFileHandle safeHandle, string lpBuffer,
        int nNumberOfBytesToWrite, out int lpNumberOfBytesWritten,
        IntPtr lpOverlapped);

    // To detect redundant calls
    private bool _disposed = false;
    private bool _created = false;
    private SafeFileHandle _safeHandle;
    private readonly string _fileName;

    public DisposableStreamResource2(string fileName) : base(fileName) => _fileName = fileName;

    public void WriteFileInfo()
    {
        if (!_created)
        {
            _safeHandle = CreateFile(
                @".\FileInfo.txt", GENERIC_WRITE, 0, IntPtr.Zero,
                OPEN_ALWAYS, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);

            _created = true;
        }

        string output = $"{_fileName}: {Size:N0} bytes\n";
        _ = WriteFile(_safeHandle, output, output.Length, out _, IntPtr.Zero);
    }

    protected override void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        // Release any managed resources here.
        if (disposing)
        {
            // Dispose managed state (managed objects).
            _safeHandle?.Dispose();
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

        _disposed = true;

        // Call the base class implementation.
        base.Dispose(disposing);
    }
}