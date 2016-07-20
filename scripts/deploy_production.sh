dotnet publish src/AviloxCore -o $CIRCLE_ARTIFACTS

HOST='ftp.myasp.net'
USER='vahaagn-001'
PASSWD='2zoltrixound'
LOCALPATH=$CIRCLE_ARTIFACTS
DIR='site1'

find $LOCALPATH -type f -exec curl -u $USER:$PASSWD --ftp-create-dirs -T $(cut -d/ -f3- <<< {}) ftp://$HOST/$DIR/$(cut -d/ -f3- <<< {}) \;