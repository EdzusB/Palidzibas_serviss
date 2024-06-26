// This file was auto-generated by ML.NET Model Builder. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ML;
using Palidzibas_servissML.Model;

namespace Palidzibas_servissML.Model
{
    // Klase, kas apraksta mode�a pat�ri�u
    public class ConsumeModel
    {
        // Statiskais objekts, kas uzglab� sl�gtu prognoz��anas dzin�ju
        private static Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictionEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(CreatePredictionEngine);

        // Metode, lai pat�r�tu modeli j�su lietotn�
        public static ModelOutput Predict(ModelInput input)
        {
            // Veic prognozi, izmantojot sagatavoto prognoz��anas dzin�ju
            ModelOutput result = PredictionEngine.Value.Predict(input);
            return result;
        }

        // Metode, kas veido prognoz��anas dzin�ju
        public static PredictionEngine<ModelInput, ModelOutput> CreatePredictionEngine()
        {
            // Izveido jaunu ML kontekstu
            MLContext mlContext = new MLContext();

            // Iel�d� modeli un izveido prognoz��anas dzin�ju
            string modelPath = @"C:\Users\Lietotajs\Documents\Palidzibas_serviss\Palidzibas_serviss\Palidzibas_servissML.Model\MLModel.zip";
            ITransformer mlModel = mlContext.Model.Load(modelPath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            return predEngine;
        }
    }
}

