@echo off
IF NOT "%~1"=="" (
	echo %1
)
IF EXIST TestGitHub (
	svn revert --depth=infinity TestGitHub
	svn update TestGitHub
) ELSE (
	svn checkout https://github.com/bihuutue/Internship2016/trunk/TestGitHub TestGitHub
)

ECHO Success

pause