#-------------------------------------------------
#
# Project created by QtCreator 2014-05-20T20:47:51
#
#-------------------------------------------------

QT       -= gui

TARGET = rab
TEMPLATE = lib

DEFINES += RAB_LIBRARY

SOURCES += rab.cpp

HEADERS += rab.h\
        rab_global.h \
    poparray.h

symbian {
    MMP_RULES += EXPORTUNFROZEN
    TARGET.UID3 = 0xE304D960
    TARGET.CAPABILITY = 
    TARGET.EPOCALLOWDLLDATA = 1
    addFiles.sources = rab.dll
    addFiles.path = !:/sys/bin
    DEPLOYMENT += addFiles
}

unix:!symbian {
    maemo5 {
        target.path = /opt/usr/lib
    } else {
        target.path = /usr/lib
    }
    INSTALLS += target
}
