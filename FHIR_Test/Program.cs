// See https://aka.ms/new-console-template for more information
using FHIR_Test;

Console.WriteLine("Testing FHIR CRUID Operation!");
new TestPatientRecord().CreatePatient();
new TestPatientRecord().GetPatientList();
new TestPatientRecord().UpdatePatientRecord();
new TestPatientRecord().DeletePatientRecord();
Console.WriteLine("Testing FHIR CRUID Operation is Done");