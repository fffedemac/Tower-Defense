using UnityEngine;

public static class Vector3Extensions
{
    public static Vector3 PredictPosition(Vector3 myPosition, Vector3 targetPosition, Vector3 targetVelocity, float timePrediction)
    {
        float predictionTime = Vector3.Distance(myPosition, targetPosition) / timePrediction;
        return targetPosition + targetVelocity * predictionTime;
    }
}
