#!/bin/bash

# template file
TEMPLATE_FILE="git_version.template"
# generated version file
VERSION_FILE="version.h"

TEMPLATE_PATH=$2$TEMPLATE_FILE
#echo $TEMPLATE_PATH
#echo $VERSION_FILE

# $1 is the prefix of Git Tag, and default is "bb3-v"
if [ ! $1 ]; then
    TAG_HEADER="sdk-v"
else
    TAG_HEADER=$1
fi
TAG_HEADER_LEN=`echo $TAG_HEADER | wc -c`
#echo $TAG_HEADER_LEN

# get full describe version
FULL_VERSION=`git describe`
# set version to 0.0.0 if no tag name
if [ ! $FULL_VERSION ]; then
    FULL_VERSION=$TAG_HEADER"0.0.0"
fi
#echo $FULL_VERSION

# remove tag header
PROJ_VERSION=`echo $FULL_VERSION | cut -c $TAG_HEADER_LEN-`
#echo $PROJ_VERSION

# split version to five fields
TAG_VERSION=`echo $PROJ_VERSION | awk -F '-' '{print $1}'`
#echo $TAG_VERSION
MAJOR=`echo $TAG_VERSION | awk -F '.' '{print $1}'`
MINOR=`echo $TAG_VERSION | awk -F '.' '{print $2}'`
REVISION=`echo $TAG_VERSION | awk -F '.' '{print $3}'`
BUILDNUM=`echo $PROJ_VERSION | awk -F '-' '{print $2}'`
if [ ! $BUILDNUM ]; then
    BUILDNUM=0
fi
GIT_CMTID=`git log --pretty=oneline -1 | cut -c 1-8`

#echo $MAJOR.$MINOR.$REVISION.$BUILDNUM
#echo $GIT_CMTID

# build time
BUILDING_TIME=`env LANG=en_US.UTF-8 date '+%a %b %e %R:%S %Y'`
#echo $BUILDING_TIME

# substitute version&time in template
`cat $TEMPLATE_PATH | sed -e "s/MAJOR_T/$MAJOR/g" \
                     -e "s/MINOR_T/$MINOR/g" \
                     -e "s/REVISION_T/$REVISION/g" \
                     -e "s/BUILDNUM_T/$BUILDNUM/g" \
                     -e "s/BUILDTIME_T/$BUILDING_TIME/g"    \
                     -e "s/GITCMTID_T/$GIT_CMTID/g" \
                    > $VERSION_FILE`

# show result
echo "Generated Version File :"
cat $VERSION_FILE
