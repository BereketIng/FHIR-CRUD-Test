using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHIR_Test
{
    public class TestPatientRecord
    {
        public void CreatePatient()
        {
            try
            {
                var client = new FhirClient("http://localhost:4080");
                client.Settings.PreferredFormat = ResourceFormat.Xml;
                client.Settings.PreferredReturn = Prefer.ReturnRepresentation;
                

                var pt = new Patient();
                pt.Name = new List<HumanName>();
                var hName = new HumanName();
                hName.Family = "Lapiso";
                hName.Given = new List<string>();
                hName.Text = "Bereket Teketel Lapiso";
                pt.Name.Add(hName);
                var result = client.Create<Patient>(pt);
                Console.WriteLine("PatientID" +result.Id);

                Console.WriteLine("Create is Done");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public void GetPatientList()
        {
            try
            {
                var client = new FhirClient("http://localhost:4080");
                var patient = client.Read<Patient>("Patient/94519751-f4de-4f83-bd73-75ec820d650e");
                if (patient != null)
                {
                    Console.WriteLine("PatientName " + patient.Name[0].Text);
                }
                Console.WriteLine("Search is Done");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }



        public void UpdatePatientRecord()
        {
            try
            {
                var client = new FhirClient("http://localhost:4080");
                var pt = client.Read<Patient>("Patient/94519751-f4de-4f83-bd73-75ec820d650e");
                pt.Name.Add(new HumanName().WithGiven("Bereket").AndFamily("Muhammed"));
                var updated_pat = client.Update(pt);
                Console.WriteLine("Update is Done");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeletePatientRecord()
        {
            try
            {
                var client = new FhirClient("http://localhost:4080");
                client.Delete("Patient//94519751-f4de-4f83-bd73-75ec820d650e");
                Console.WriteLine("Delete is Done");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
