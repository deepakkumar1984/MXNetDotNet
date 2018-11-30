@echo off
@call SetEnv.bat

set CURDIR=%cd%
mkdir "%ARTIFACTS%"

cd incubator-mxnet

git submodule update --init --recursive

set BUILDDIR=build_cpu
mkdir %BUILDDIR%
cd %BUILDDIR%
cmake -G "Visual Studio 14 2015 Win64" ^
      -D USE_CUDA:BOOL=0 ^
      -D USE_CUDNN:BOOL=0 ^
      -D USE_CPP_PACKAGE:BOOL=0 ^
..

cmake --build . --config %1

rem **************************************
rem Collect artifacts
rem **************************************
xcopy "%1\libmxnet.dll" "%CURDIR%\%ARTIFACTS%" /y

cd %CURDIR%
xcopy "%MXNET_HOME%\3rdParty\bin\*" %ARTIFACTS% /y


rem **************************************
rem Download mingw64
rem **************************************
wget %MINGW_URL%%MINGW_ZIP%
python copy_mingw64.py %MINGW_ZIP%
move mingw64_dll\*.dll %ARTIFACTS%
del %MINGW_ZIP%
rmdir mingw64_dll