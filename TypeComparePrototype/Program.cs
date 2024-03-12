// See https://aka.ms/new-console-template for more information
using SHVXGate.ServiceContracts;
using TypeComparePrototype;

SHVXGate.ServiceContracts.ReturnData returnData = new SHVXGate.ServiceContracts.ReturnData();

TypeComparePrototype.ReturnData returnData1 = new TypeComparePrototype.ReturnData();

Console.WriteLine(returnData.GetType());
Console.WriteLine(returnData1.GetType());
Console.WriteLine(typeof(SHVXGate.ServiceContracts.ReturnData).IsInstanceOfType(returnData));

