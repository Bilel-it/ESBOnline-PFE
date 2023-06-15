provider "vsphere" {
  user                 = var.vsphere_user
  password             = var.vsphere_password
  vsphere_server       = var.vsphere_server
  allow_unverified_ssl = true
}

data "vsphere_datacenter" "dc" {
  name = "ha-datacenter"
}

data "vsphere_datastore" "datastore" {
  name          = "Cluster_DataStore1"
  datacenter_id = "${data.vsphere_datacenter.dc.id}"
}

data "vsphere_resource_pool" "pool" {
  name          = "terraform"
  datacenter_id = "${data.vsphere_datacenter.dc.id}"
}

data "vsphere_network" "mgmt_lan" {
  name          = "admin"
  datacenter_id = "${data.vsphere_datacenter.dc.id}"
}


resource "vsphere_virtual_machine" "vm3" {
  name             = "k8s-win-worker05-local"
  resource_pool_id = data.vsphere_resource_pool.pool.id
  datastore_id     = data.vsphere_datastore.datastore.id
  num_cpus         = 4
  memory           = 16384
  guest_id         = "windowsServer64Guest"
  wait_for_guest_net_timeout = 0
  network_interface {
    network_id = data.vsphere_network.mgmt_lan.id
  }
  disk {
    label = "disk0"
    size  = 150
  }
  //clone {
  //  template_uuid = data.vsphere_virtual_machine.template.id
  //} 

}


