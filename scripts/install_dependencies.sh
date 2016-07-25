# ------------------------------
# INSTALL DEPENDENCIES
# ------------------------------

# ------------------------------
# Prepare logs folder
# ------------------------------
VAR_LOGS=$CIRCLE_ARTIFACTS/_logs
mkdir -p $VAR_LOGS
exec 2>&1 | tee $VAR_LOGS/_full_log.txt

# ------------------------------
# Install DOTNET if not yet installed
# ------------------------------
VAR_DOTNET='dotnet-dev-1.0.0-preview2-003121'
if [ $(dpkg-query -W -f='${Status}' $VAR_DOTNET 2>/dev/null | grep -c "ok installed") -eq 0 ];
then
	sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet/ trusty main" > /etc/apt/sources.list.d/dotnetdev.list'
	sudo apt-key adv --keyserver apt-mo.trafficmanager.net --recv-keys 417A0893
	sudo apt-get update
	sudo apt-get install $VAR_DOTNET
	sudo dpkg -L $VAR_DOTNET > $VAR_LOGS/dotnet_location.txt
fi

# ------------------------------
# Install LFTP if not yet installed
# ------------------------------
VAR_LFTP='lftp'
if [ $(dpkg-query -W -f='${Status}' $VAR_LFTP 2>/dev/null | grep -c "ok installed") -eq 0 ];
then
	sudo apt-get install $VAR_LFTP
	sudo dpkg -L $VAR_LFTP > $VAR_LOGS/lftp_location.txt
fi