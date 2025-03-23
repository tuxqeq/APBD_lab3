// See https://aka.ms/new-console-template for more information

using APBD_lab3;

var liquidContainer = new LiquidContainer(100, 10, 5, 50, 5, 200, "Water");
var gasContainer = new GasContainer(80, 8, 4, 40, 4, 150, 1.2);
var refrigeratedContainer = new RefrigeratedContainer(120, 12, 6, 60, 6, 250, 5, "Fish");

// Create ships
var ship1 = new ContainerShip(10, 1000, 30);
var ship2 = new ContainerShip(8, 800, 25);

// Load cargo into containers
liquidContainer.LoadCargo(30);
gasContainer.LoadCargo(20);
refrigeratedContainer.LoadCargo(40);

// Load containers onto ship1
ship1.AddContainer(liquidContainer);
ship1.AddContainer(gasContainer);

// Load a list of containers onto ship2
var containerList = new List<Container> { refrigeratedContainer };
ship2.AddContainers(containerList);

// Remove a container from ship1
ship1.RemoveContainer(gasContainer);

// Replace a container on ship1
ship1.ReplaceContainer(liquidContainer.Id, gasContainer);

// Transfer a container from ship1 to ship2
ship1.TransferContainer(ship2, gasContainer);

// Print information about a given container
ship1.PrintContainerInfo(liquidContainer.Id);

// Print information about ships and their cargo
ship1.PrintShipInfo();
ship2.PrintShipInfo();