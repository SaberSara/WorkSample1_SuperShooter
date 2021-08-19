@echo off

md  _Junks    _IgnoreFiles    _IgnoreFiles\Raw    _Prototype-GameDev    _ThirdParties   Assets2D    Assets2D\App    Assets2D\App\Icon    Assets2D\App\SplashScreen    Assets2D\UI    Assets2D\UI\GUI    Assets3D    Assets3D\Materials    Assets3D\Models    Assets3D\Models\Characters    Assets3D\Models\Environments    Assets3D\Models\Props    Assets3D\Models\Props    Editor\    Editor\EditorScripts    Editor\Gizmos    Fonts    Prefabs    Resource    Scenes    Scripts    Scripts\AR    Scripts\Components    Scripts\Entities    Scripts\Helpers    Scripts\Managers    Scripts\NonMonoBehaviorScripts    Scripts\ScriptableObjects    Scripts\UIBuilders    Scripts\GUIBuilders    Scripts\VR    Audios    Audios\AmbientSounds    Audios\SFX    Audios\VoiceOvers    StreamingAssets    Plugin    Renders    Renders\Shaders    Renders\Pipelines\URPipelines    Renders\Pipelines\HDRPipelines 

title Custom Text File
cls
set /p txt=What is the project name? ; 




echo "////--------------YINYANGGAMES------2021---//// This is a ReadMe file for the Unity project "%txt%" , please fill the file with the template text and remplace the informations: https://1drv.ms/t/s!AgDnFacvwTrJgaQ5BYmaT28cwvljQA?e=waPnHg"  > "ReadMe.txt"
exit