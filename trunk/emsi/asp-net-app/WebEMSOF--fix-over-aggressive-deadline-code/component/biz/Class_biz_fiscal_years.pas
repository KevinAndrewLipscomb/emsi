unit Class_biz_fiscal_years;

interface

type
  TClass_biz_fiscal_years = class
  private
    { Private Declarations }
  public
    constructor Create;
    function IdOfCurrent: string;
    function IdOfDesignator(designator: string): string;
  end;

implementation

uses
  Class_db_fiscal_years;

constructor TClass_biz_fiscal_years.Create;
begin
  inherited Create;
  // TODO: Add any constructor code here
end;

function TClass_biz_fiscal_years.IdOfCurrent: string;
begin
  IdOfCurrent := TClass_db_fiscal_years.Create.IdOfCurrent;
end;

function TClass_biz_fiscal_years.IdOfDesignator(designator: string): string;
begin
  IdOfDesignator := TClass_db_fiscal_years.Create.IdOfDesignator(designator);
end;

end.
