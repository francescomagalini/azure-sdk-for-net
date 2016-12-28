// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineDataDisk.Update;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineDataDisk.UpdateDefinition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Update;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition;

    /// <summary>
    /// The stage of virtual machine definition allowing to specify additional network interfaces.
    /// </summary>
    public interface IWithSecondaryNetworkInterface 
    {
        /// <summary>
        /// Removes a network interface associated with virtual machine.
        /// </summary>
        /// <param name="name">The name of the secondary network interface to remove.</param>
        /// <return>The stage representing updatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutSecondaryNetworkInterface(string name);

        /// <summary>
        /// Associate an existing network interface with the virtual machine.
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="networkInterface">An existing network interface.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithExistingSecondaryNetworkInterface(INetworkInterface networkInterface);

        /// <summary>
        /// Create a new network interface to associate with the virtual machine, based on the
        /// provided definition.
        /// Note this method's effect is additive, i.e. each time it is used, the new secondary
        /// network interface added to the virtual machine.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new network interface.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithNewSecondaryNetworkInterface(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface> creatable);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify data disk configuration.
    /// </summary>
    public interface IWithDataDisk 
    {
        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk along with
        /// it's configuration.
        /// </summary>
        /// <param name="name">The name for the data disk.</param>
        /// <return>The stage representing configuration for the data disk.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineDataDisk.UpdateDefinition.IAttachExistingDataDisk<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate> DefineExistingDataDisk(string name);

        /// <summary>
        /// Specifies a new blank data disk to be attached to the virtual machine along with it's configuration.
        /// </summary>
        /// <param name="name">The name for the data disk.</param>
        /// <return>The stage representing configuration for the data disk.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineDataDisk.UpdateDefinition.IAttachNewDataDisk<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate> DefineNewDataDisk(string name);

        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container holding the VHD file.</param>
        /// <param name="vhdName">The name for the VHD file.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithExistingDataDisk(string storageAccountName, string containerName, string vhdName);

        /// <summary>
        /// Begins the description of an update of an existing data disk of this virtual machine.
        /// </summary>
        /// <param name="name">The name of the disk.</param>
        /// <return>The stage representing updating configuration for  data disk.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineDataDisk.Update.IUpdate UpdateDataDisk(string name);

        /// <summary>
        /// Specifies that a new blank data disk needs to be attached to virtual machine.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The stage representing creatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithNewDataDisk(int sizeInGB);

        /// <summary>
        /// Detaches a data disk with the given name from the virtual machine.
        /// </summary>
        /// <param name="name">The name of the data disk to remove.</param>
        /// <return>The stage representing updatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutDataDisk(string name);

        /// <summary>
        /// Detaches a data disk with the given logical unit number from the virtual machine.
        /// </summary>
        /// <param name="lun">The logical unit number of the data disk to remove.</param>
        /// <return>The stage representing updatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutDataDisk(int lun);
    }

    /// <summary>
    /// The template for an update operation, containing all the settings that
    /// can be modified.
    /// Call Update.apply() to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>,
        IUpdateWithTags<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate>,
        IWithDataDisk,
        IWithSecondaryNetworkInterface,
        IWithExtension
    {
        /// <summary>
        /// Specifies the size of the OSDisk in GB.
        /// </summary>
        /// <param name="size">The VHD size.</param>
        /// <return>The stage representing updatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithOsDiskSizeInGb(int size);

        /// <summary>
        /// Specifies the caching type for the Operating System disk.
        /// </summary>
        /// <param name="cachingType">The caching type.</param>
        /// <return>The stage representing updatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithOsDiskCaching(CachingTypes cachingType);

        /// <summary>
        /// Specifies the new size for the virtual machine.
        /// </summary>
        /// <param name="sizeName">The name of the size for the virtual machine as text.</param>
        /// <return>The stage representing updatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithSize(string sizeName);

        /// <summary>
        /// Specifies the new size for the virtual machine.
        /// </summary>
        /// <param name="size">A size from the list of available sizes for the virtual machine.</param>
        /// <return>The stage representing updatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithSize(VirtualMachineSizeTypes size);
    }

    /// <summary>
    /// The stage of the virtual machine definition allowing to specify extensions.
    /// </summary>
    public interface IWithExtension 
    {
        /// <summary>
        /// Begins the description of an update of an existing extension of this virtual machine.
        /// </summary>
        /// <param name="name">The reference name for the extension.</param>
        /// <return>The stage representing updatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Update.IUpdate UpdateExtension(string name);

        /// <summary>
        /// Specifies definition of an extension to be attached to the virtual machine.
        /// </summary>
        /// <param name="name">The reference name for the extension.</param>
        /// <return>The stage representing configuration for the extension.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition.IBlank<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate> DefineNewExtension(string name);

        /// <summary>
        /// Detaches an extension with the given name from the virtual machine.
        /// </summary>
        /// <param name="name">The reference name for the extension to be removed/uninstalled.</param>
        /// <return>The stage representing updatable VM definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate WithoutExtension(string name);
    }
}