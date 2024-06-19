using UnityEngine;

public class ScreenOrientationScript : MonoBehaviour
{
    public enum Orientation
    {
        LandscapeLeft,
        LandscapeRight,
        Portrait,
        PortraitUpsideDown
    }

    [SerializeField]
    public Orientation selectOrientation;


    
    private void Awake()
    {
        switch (selectOrientation)
        {
            case Orientation.LandscapeLeft:
                ChangeOrientation(ScreenOrientation.LandscapeLeft);
                break;
            case Orientation.LandscapeRight:
                ChangeOrientation(ScreenOrientation.LandscapeRight);
                break;
            case Orientation.Portrait:
                ChangeOrientation(ScreenOrientation.Portrait);
                break;
            case Orientation.PortraitUpsideDown:
                ChangeOrientation(ScreenOrientation.PortraitUpsideDown);
                break;
        }

    }


    //Changing screen Orientation according to the selected value
    void ChangeOrientation(ScreenOrientation orientation)
    {
        Screen.orientation = orientation;
        //Debug.Log(orientation);
    }
}
