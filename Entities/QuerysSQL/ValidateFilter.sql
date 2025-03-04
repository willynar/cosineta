/****** Object:  UserDefinedFunction [dbo].[ValidateFilter]    Script Date: 7/04/2024 3:16:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER FUNCTION [dbo].[ValidateFilter]
(
	@ProductIdFromTBL INT NULL,
    @ProductNameFromTBL NVARCHAR(MAX) NULL,
    @ProductDescriptionFromTBL NVARCHAR(MAX) NULL,
    @ProductImageFromTBL NVARCHAR(MAX) NULL,
    @TypeIdFromTBL INT NULL,
    @PriceFromTBL DECIMAL(18,2) NULL,
    @IngredientsFromTBL NVARCHAR(MAX) NULL,
    @ProductActiveFromTBL BIT NULL,
	@ReviewFromTBL DECIMAL(18,2) NULL,
    @ApplicationUserIdFromTBL NVARCHAR(MAX) NULL,
    @UserNameFromTBL NVARCHAR(MAX) NULL,
    @UserLastNameFromTBL NVARCHAR(MAX) NULL,
    @SPCategoryIdFromTBL INT NULL,
    @SPFeactureIdFromTBL INT NULL,
    @StarTimeFromTBL DATETIME NULL,
    @EndTimeFromTBL DATETIME NULL,
    @ServingFromTBL INT NULL,
	@ApplicationUserIdValue NVARCHAR(MAX) NULL,
    @LongitudeUser NVARCHAR(MAX) NULL,
    @LatitudeUser NVARCHAR(MAX) NULL,
    @Filter NVARCHAR(MAX) NULL,
    @FilterValue NVARCHAR(MAX) NULL,
    @PriceMin DECIMAL(18,2) NULL,
    @PriceMax DECIMAL(18,2) NULL,
    @Review DECIMAL(18,2) NULL,
    @StarTime DATETIME NULL,
    @EndTime DATETIME NULL,
    @Serving INT NULL,
	@ApplicationUserId NVARCHAR(MAX) NULL,
    @Longitude NVARCHAR(MAX) NULL,
    @Latitude NVARCHAR(MAX) NULL
)
RETURNS BIT
AS
BEGIN
	DECLARE @Result BIT;

		SET @Result = (CASE 
						WHEN 
							   (CASE
									WHEN @Filter LIKE '%PriceRange%' THEN (CASE WHEN (@PriceFromTBL >= @PriceMin  AND @PriceFromTBL <= @PriceMax)  THEN '1' ELSE '0' END) + ','
									ELSE ''
								END  +
								CASE
									WHEN @Filter LIKE '%Review%' THEN (CASE WHEN  @Review >= @ReviewFromTBL  THEN '1' ELSE '0' END) + ','
									ELSE ''
								END +
								CASE
									WHEN @Filter LIKE '%Category%' THEN (CASE WHEN  @SPCategoryIdFromTBL IS NOT NULL  THEN '1' ELSE '0' END) + ','
									ELSE ''
								END +
								CASE
									WHEN @Filter LIKE '%Feature%' THEN (CASE WHEN  @SPFeactureIdFromTBL IS NOT NULL  THEN '1' ELSE '0' END) + ','
									ELSE ''
								END +
								CASE
									WHEN @Filter LIKE '%FilterValue%' THEN (CASE WHEN  (dbo.ValidateFilterValue(@ProductIdFromTBL,@ProductNameFromTBL,@ProductDescriptionFromTBL,@ProductNameFromTBL,@TypeIdFromTBL,@PriceFromTBL,@IngredientsFromTBL,@ProductActiveFromTBL,@ReviewFromTBL,@ApplicationUserIdFromTBL,@UserNameFromTBL,@UserLastNameFromTBL,@FilterValue) = 1)  THEN '1' ELSE '0' END) + ','
									ELSE ''
								END +
								CASE
									WHEN @Filter LIKE '%Time%' THEN (CASE WHEN  (@EndTimeFromTBL >= @StarTime  AND @StarTimeFromTBL <= @EndTime)  THEN '1' ELSE '0' END) + ','
									ELSE ''
								END +
								CASE
									WHEN @Filter LIKE '%Serving%' THEN (CASE WHEN  @Serving >= @ServingFromTBL  THEN '1' ELSE '0' END) + ','
									ELSE ''
								END +
								CASE
									WHEN @Filter LIKE '%ApplicationUserId%' THEN (CASE WHEN  @ApplicationUserId >= @ApplicationUserIdValue  THEN '1' ELSE '0' END) + ','
									ELSE ''
								END +
								CASE
									WHEN @Filter LIKE '%Location%' THEN (CASE WHEN  SQRT(POWER(CAST(ISNULL(@LatitudeUser,0) AS DECIMAL) - CAST(ISNULL(@Latitude,0) AS DECIMAL), 2) + POWER(CAST(ISNULL(@LongitudeUser,0) AS DECIMAL) - CAST(ISNULL(@Longitude,0) AS DECIMAL), 2)) * 111.12 <= 100 THEN '1' ELSE '0' END) + ','
									ELSE ''
								END
								+
								CASE
									WHEN @Filter IS NULL AND @FilterValue IS NULL THEN (CASE WHEN 1 = 1  THEN '1' ELSE '0' END) + ','
									ELSE ''
								END 
							) LIKE '%0%' 
							THEN 0
						ELSE 
							1
					END);
    RETURN @Result;
END;
