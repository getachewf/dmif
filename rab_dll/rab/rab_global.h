#ifndef RAB_GLOBAL_H
#define RAB_GLOBAL_H

#include <QtCore/qglobal.h>

#if defined(RAB_LIBRARY)
#  define RABSHARED_EXPORT Q_DECL_EXPORT
#else
#  define RABSHARED_EXPORT Q_DECL_IMPORT
#endif

#endif // RAB_GLOBAL_H
