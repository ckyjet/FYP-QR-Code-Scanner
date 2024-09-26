using UnityEngine;
using Vuforia;
using TMPro;
using UnityEngine.SceneManagement; // Required for scene management.

public class SimpleBarcodeScanner : MonoBehaviour
{
    public TMPro.TextMeshProUGUI barcodeAsText;
    BarcodeBehaviour mBarcodeBehaviour;
    private bool barcodeScanned = false;  // To prevent repeated scanning.

    void Start()
    {
        mBarcodeBehaviour = GetComponent<BarcodeBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if barcode has been scanned and the message hasn't been displayed yet
        if (!barcodeScanned && mBarcodeBehaviour != null && mBarcodeBehaviour.InstanceData != null)
        {
            // Set the text to "Congratulations!" and prevent further updates
            barcodeAsText.text = "Congratulations!";
            barcodeScanned = true;

            // Call the method to change the scene after 2 seconds
            Invoke("GoBackToPreviousScene", 2f);  
        }
        // No else block to ensure the text stays "Congratulations!" until the scene changes
    }

    // Method to go back to the previous scene
    void GoBackToPreviousScene()
    {
        // Assuming the previous scene is in the build order just before the current one.
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(previousSceneIndex);
    }
}
