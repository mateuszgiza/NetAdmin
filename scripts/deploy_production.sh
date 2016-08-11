# ------------------------------
# DEPLOY SCRIPT
# ------------------------------
CURR_DIR=$(pwd) # save current working dir

# ------------------------------
# AviloxCore deploy section
# ------------------------------
HOST='ftp://waws-prod-db3-033.ftp.azurewebsites.windows.net'
USER='AviloxCore\vahaagn-pub'
PASSWD='2zoltrixound'
LOCALPATH=$CIRCLE_ARTIFACTS/AviloxCore
DIR='site/wwwroot'

cd $CURR_DIR
mkdir -p $LOCALPATH
dotnet publish src/Avilox.Core -o $LOCALPATH
cd $LOCALPATH
lftp -c "open -u $USER,$PASSWD $HOST; set ssl:verify-certificate no; mirror --continue --only-newer --parallel=10 -R ./ /$DIR/"

# ------------------------------
# AviloxFront deploy section
# ------------------------------
HOST='ftp://waws-prod-db3-033.ftp.azurewebsites.windows.net'
USER='Avilox\vahaagn-pub'
PASSWD='2zoltrixound'
LOCALPATH=$CIRCLE_ARTIFACTS/AviloxFront
DIR='site/wwwroot'

cd $CURR_DIR
mkdir -p $LOCALPATH
cp -R src/AviloxFront/. $LOCALPATH/
cd $LOCALPATH
lftp -c "open -u $USER,$PASSWD $HOST; set ssl:verify-certificate no; mirror --continue --only-newer --parallel=10 -R ./ /$DIR/"
