/*
** $Id$
**
** Intended to determine, for selected services, how many pt's presented
** with non-asystole non-trauma cardiac arrests and were worked.
*/
SELECT [EMSCAN-data].[incident-type], [EMSCAN-data].[bls-tx-auto-defib], [EMSCAN-data].[ekg-asystole], [EMSCAN-data].[bls-tx-cpr], [EMSCAN-data].[vehicle-num]
FROM [EMSCAN-data]
WHERE ([EMSCAN-data].[incident-type] ="07")
AND
   ([EMSCAN-data].[bls-tx-cpr] <>"NNNNN")
AND
   (
      ([EMSCAN-data].[bls-tx-auto-defib] <>"NNNNN")
   OR
      ([EMSCAN-data].[ekg-asystole] Like 'N*')
   )
AND
   (
      [EMSCAN-data].[vehicle-num] like "02156*"
   OR
      [EMSCAN-data].[vehicle-num] like "02127*"
   OR
      [EMSCAN-data].[vehicle-num] like "02136*"
   OR
      [EMSCAN-data].[vehicle-num] like "02134*"
   OR
      [EMSCAN-data].[vehicle-num] like "02097*"
   OR
      [EMSCAN-data].[vehicle-num] like "02135*"
   );
